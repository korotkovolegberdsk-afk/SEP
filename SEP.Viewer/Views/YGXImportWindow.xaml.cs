using System.Windows;
using SEP.Import.Models;

namespace SEP.Viewer.Views;

public partial class YGXImportWindow : Window
{
    public YGXImportWindow(ImportResult result)
    {
        InitializeComponent();

        InfoText.Text =
            $"Файл: {result.FileName}\n" +
            $"Компонентов: {result.ComponentsCount}";

        ComponentsGrid.ItemsSource = result.Components;
    }


    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}