using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SEP.Database;
using SEP.Database.Models;

namespace SEP.Viewer;

public partial class MainWindow : Window
{
    private readonly DatabaseManager _database = new();

    public MainWindow()
    {
        InitializeComponent();

        LoadPackages();

        PackagesTree.SelectedItemChanged += PackagesTree_SelectedItemChanged;
        PackagesTree.MouseDoubleClick += PackagesTree_MouseDoubleClick;

        SelectFirstPackage();
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

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}