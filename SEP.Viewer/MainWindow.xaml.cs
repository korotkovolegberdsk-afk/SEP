using System.Windows;
using System.Windows.Controls;
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
    }

    private void LoadPackages()
    {
        PackagesTree.Items.Clear();

        TreeViewItem chip = new()
        {
            Header = "CHIP",
            IsExpanded = true
        };

        foreach (Package package in _database.GetPackages())
        {
            chip.Items.Add(new TreeViewItem
            {
                Header = package.Name,
                Tag = package
            });
        }

        PackagesTree.Items.Add(chip);
    }

    private void PackagesTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (PackagesTree.SelectedItem is not TreeViewItem item)
            return;

        if (item.Tag is not Package package)
            return;

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