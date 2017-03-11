using System;
using System.Windows;
using System.Windows.Controls;
using WpfPageTransitions;

namespace WpfPageTransitionDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            CmbTransitionTypes.ItemsSource = Enum.GetNames(typeof(PageTransitionType));
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            var newPage = new NewPage();

            PageTransitionControl.ShowPage(newPage);
        }

        private void cmbTransitionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PageTransitionControl.TransitionType =
                (PageTransitionType)
                Enum.Parse(typeof(PageTransitionType), CmbTransitionTypes.SelectedItem.ToString(), true);
        }
    }
}