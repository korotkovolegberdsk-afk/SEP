using System.Windows;
using System.Windows.Input;

namespace SEP.Viewer.Views
{
    public partial class PackageManagerWindow : Window
    {
        public PackageManagerWindow()
        {
            InitializeComponent();
        }

        private void PackageTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editor = new PackageEditorWindow();

            editor.Owner = this;

            // Передаем выбранный элемент в редактор
            editor.Tag = PackageTree.SelectedItem;

            editor.ShowDialog();
        }
    }
}
