using System.Windows;
using System.Windows.Controls;
using SEP.Database;
using SEP.Database.Models;

namespace SEP.Viewer.Views;

public partial class PackageManagerWindow : Window
{
    private readonly DatabaseManager _database = new();

    public PackageManagerWindow()
    {
        InitializeComponent();

        PackageTree.SelectedItemChanged += PackageTree_SelectedItemChanged;

        LoadPackages();
        SelectFirstPackage();
    }

    private void LoadPackages()
    {
        PackageTree.Items.Clear();

        TreeViewItem passive = new() { Header = "Passive", IsExpanded = true };
        TreeViewItem transistors = new() { Header = "Transistors", IsExpanded = true };
        TreeViewItem ic = new() { Header = "IC", IsExpanded = true };

        foreach (Package package in _database.GetPackages())
        {
            TreeViewItem item = new()
            {
                Header = package.Name,
                Tag = package
            };

            switch (package.PackageType)
            {
                case "CHIP":
                    passive.Items.Add(item);
                    break;
                case "SOT":
                    transistors.Items.Add(item);
                    break;
                case "SOIC":
                    ic.Items.Add(item);
                    break;
                default:
                    passive.Items.Add(item);
                    break;
            }
        }

        PackageTree.Items.Add(passive);
        PackageTree.Items.Add(transistors);
        PackageTree.Items.Add(ic);
    }

    private void SelectFirstPackage()
    {
        foreach (TreeViewItem group in PackageTree.Items)
        {
            if (group.Items.Count > 0 && group.Items[0] is TreeViewItem item)
            {
                item.IsSelected = true;
                if (item.Tag is Package p)
                    ShowPackage(p);
                return;
            }
        }
    }

    private void PackageTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (PackageTree.SelectedItem is TreeViewItem item &&
            item.Tag is Package package)
        {
            ShowPackage(package);
        }
    }

    private void ShowPackage(Package package)
    {
        NameText.Text = package.Name;
        TypeText.Text = package.PackageType;
        LengthText.Text = $"{package.Length:F2} mm";
        WidthText.Text = $"{package.Width:F2} mm";
        HeightText.Text = $"{package.Height:F2} mm";
        if (DescriptionText != null) DescriptionText.Text = package.Description;
        if (PitchText != null) PitchText.Text = $"{package.Pitch:F2} mm";
        PinsText.Text = package.Pins.ToString();
    }
}
