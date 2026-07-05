using System.Windows;
using SEP.Database.Models;

namespace SEP.Viewer
{
    public partial class PackageEditor : Window
    {
        public Package CurrentPackage { get; }

        // Новый корпус
        public PackageEditor() : this(new Package())
        {
        }

        // Редактирование существующего корпуса
        public PackageEditor(Package package)
        {
            InitializeComponent();

            CurrentPackage = package;

            NameBox.Text = package.Name;
            TypeBox.Text = package.PackageType;
            LengthBox.Text = package.Length.ToString();
            WidthBox.Text = package.Width.ToString();
            HeightBox.Text = package.Height.ToString();
            PinsBox.Text = package.Pins.ToString();
            DescriptionBox.Text = package.Description;

            SaveButton.Click += SaveButton_Click;
            CancelButton.Click += CancelButton_Click;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPackage.Name = NameBox.Text.Trim();
            CurrentPackage.PackageType = TypeBox.Text.Trim();
            CurrentPackage.Description = DescriptionBox.Text.Trim();

            double.TryParse(LengthBox.Text, out double length);
            double.TryParse(WidthBox.Text, out double width);
            double.TryParse(HeightBox.Text, out double height);
            int.TryParse(PinsBox.Text, out int pins);

            CurrentPackage.Length = length;
            CurrentPackage.Width = width;
            CurrentPackage.Height = height;
            CurrentPackage.Pins = pins;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}