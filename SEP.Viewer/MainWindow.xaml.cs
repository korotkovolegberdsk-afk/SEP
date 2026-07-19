using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using SEP.Database;
using SEP.Database.Models;
using SEP.Import.Parsers;
using SEP.Viewer.Views;

namespace SEP.Viewer;

public partial class MainWindow : Window
{
    private readonly DatabaseManager _database = new();

    public MainWindow()
    {
        InitializeComponent();

        NewPackageButton.Click += NewPackageButton_Click;
        DeletePackageButton.Click += DeletePackageButton_Click;
        CopyPackageButton.Click += CopyPackageButton_Click;

        ImportYGXMenuItem.Click += ImportYGXMenuItem_Click;

        LoadPackages();

        PackagesTree.SelectedItemChanged += PackagesTree_SelectedItemChanged;
        PackagesTree.MouseDoubleClick += PackagesTree_MouseDoubleClick;

        SelectFirstPackage();
    }


    private void ImportYGXMenuItem_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Filter = "YGX files (*.ygx)|*.ygx|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() != true)
            return;

        try
        {
            YGXParser parser = new();

            var result = parser.Parse(dialog.FileName);

            YGXImportWindow window = new(result)
            {
                Owner = this
            };

            window.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Ошибка импорта YGX",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }


    private void LoadPackages(string filter = "")
    {
        PackagesTree.Items.Clear();

        TreeViewItem chip = new()
        {
            Header = "CHIP",
            IsExpanded = true
        };

        foreach (Package package in _database.GetPackages())
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                string text = filter.ToLower();

                if (!package.Name.ToLower().Contains(text) &&
                    !package.PackageType.ToLower().Contains(text))
                    continue;
            }

            chip.Items.Add(new TreeViewItem
            {
                Header = package.Name,
                Tag = package
            });
        }

        PackagesTree.Items.Add(chip);
    }


    private void SelectFirstPackage()
    {
        if (PackagesTree.Items.Count == 0)
            return;

        if (PackagesTree.Items[0] is not TreeViewItem group)
            return;

        if (group.Items.Count == 0)
            return;

        if (group.Items[0] is not TreeViewItem item)
            return;

        item.IsSelected = true;

        if (item.Tag is Package package)
            ShowPackage(package);
    }


    private void PackagesTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (PackagesTree.SelectedItem is not TreeViewItem item)
            return;

        if (item.Tag is not Package package)
            return;

        ShowPackage(package);
    }


    private void PackagesTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (PackagesTree.SelectedItem is not TreeViewItem item)
            return;

        if (item.Tag is not Package package)
            return;

        PackageEditor editor = new(package)
        {
            Owner = this
        };

        if (editor.ShowDialog() == true)
        {
            _database.UpdatePackage(package);

            ShowPackage(package);

            item.Header = package.Name;
        }
    }


    private void NewPackageButton_Click(object sender, RoutedEventArgs e)
    {
        PackageEditor editor = new()
        {
            Owner = this
        };

        if (editor.ShowDialog() != true)
            return;

        _database.AddPackage(editor.CurrentPackage);

        LoadPackages();
        SelectFirstPackage();
    }


    private void DeletePackageButton_Click(object sender, RoutedEventArgs e)
    {
        if (PackagesTree.SelectedItem is not TreeViewItem item)
            return;

        if (item.Tag is not Package package)
            return;

        MessageBoxResult result = MessageBox.Show(
            $"Удалить корпус \"{package.Name}\"?",
            "Удаление корпуса",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (result != MessageBoxResult.Yes)
            return;

        _database.RemovePackage(package);

        LoadPackages();
        SelectFirstPackage();
    }


    private void CopyPackageButton_Click(object sender, RoutedEventArgs e)
    {
        if (PackagesTree.SelectedItem is not TreeViewItem item ||
            item.Tag is not Package src)
            return;

        Package copy = new()
        {
            Name = src.Name + "_COPY",
            PackageType = src.PackageType,
            Description = src.Description,
            Length = src.Length,
            Width = src.Width,
            Height = src.Height,
            Pitch = src.Pitch,
            Pins = src.Pins
        };

        PackageEditor editor = new(copy)
        {
            Owner = this
        };

        if (editor.ShowDialog() != true)
            return;

        _database.AddPackage(editor.CurrentPackage);

        LoadPackages();
        SelectFirstPackage();
    }


    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        LoadPackages(SearchBox.Text);
        SelectFirstPackage();
    }


    private void ShowPackage(Package package)
    {
        NameText.Text = package.Name;
        TypeText.Text = package.PackageType;
        DescriptionText.Text = package.Description;
        LengthText.Text = $"{package.Length:F2} mm";
        WidthText.Text = $"{package.Width:F2} mm";
        HeightText.Text = $"{package.Height:F2} mm";
        PinsText.Text = package.Pins.ToString();
    }



    private void MasterLibrary_Click(object sender, RoutedEventArgs e)
    {
        PackageManagerWindow window = new()
        {
            Owner = this
        };

        window.ShowDialog();
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}