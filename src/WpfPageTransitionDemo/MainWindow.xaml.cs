// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main windows class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfPageTransitionDemo;

/// <summary>
/// The main windows class.
/// </summary>
public partial class MainWindow
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        this.InitializeComponent();
        this.CmbTransitionTypes.ItemsSource = Enum.GetNames(typeof(PageTransitionType));
    }

    /// <summary>
    /// Handles the button click for the next page.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ButtonNextPageClick(object sender, RoutedEventArgs e)
    {
        var newPage = new NewPage();
        this.PageTransitionControl.ShowPage(newPage);
    }

    /// <summary>
    /// Handles the combo box transition type selection changed event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ComboboxTransitionTypesSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        this.PageTransitionControl.TransitionType =
            (PageTransitionType)
            Enum.Parse(typeof(PageTransitionType), this.CmbTransitionTypes.SelectedItem.ToString() ?? string.Empty, true);
    }
}
