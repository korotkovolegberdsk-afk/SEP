using System.Windows;
using SEP.Database.Models;

namespace SEP.Viewer.Views
{
    public partial class PackageEditorWindow : Window
    {
        public Package CurrentPackage { get; }

        public PackageEditorWindow()
        {
            InitializeComponent();
            CurrentPackage = new Package();
        }

        public PackageEditorWindow(Package package) : this()
        {
            CurrentPackage = package;

            NameBox.Text = package.Name;
            TypeBox.Text = package.PackageType;
            LengthBox.Text = package.Length.ToString();
            WidthBox.Text = package.Width.ToString();
            HeightBox.Text = package.Height.ToString();
            PitchBox.Text = package.Pitch.ToString();
            PinsBox.Text = package.Pins.ToString();

            StencilThicknessBox.Text = package.StencilThickness.ToString();
            ApertureReductionBox.Text = package.ApertureReduction.ToString();
            AOIAlgorithmBox.Text = package.AOIAlgorithm;
            NotesBox.Text = package.Notes;

            DescriptionBox.Text = package.Description;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPackage.Name = NameBox.Text;
            CurrentPackage.PackageType = TypeBox.Text;
            CurrentPackage.Description = DescriptionBox.Text;

            double.TryParse(LengthBox.Text, out var length);
            double.TryParse(WidthBox.Text, out var width);
            double.TryParse(HeightBox.Text, out var height);
            double.TryParse(PitchBox.Text, out var pitch);
            double.TryParse(StencilThicknessBox.Text, out var stencil);
            double.TryParse(ApertureReductionBox.Text, out var reduction);
            int.TryParse(PinsBox.Text, out var pins);

            CurrentPackage.Length = length;
            CurrentPackage.Width = width;
            CurrentPackage.Height = height;
            CurrentPackage.Pitch = pitch;
            CurrentPackage.Pins = pins;

            CurrentPackage.StencilThickness = stencil;
            CurrentPackage.ApertureReduction = reduction;
            CurrentPackage.AOIAlgorithm = AOIAlgorithmBox.Text;
            CurrentPackage.Notes = NotesBox.Text;

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