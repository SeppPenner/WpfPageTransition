// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageTransition.xaml.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The page transition.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfPageTransitions;

/// <summary>
/// The page transition.
/// </summary>
public partial class PageTransition
{
    /// <summary>
    /// The transition property.
    /// </summary>
    public static readonly DependencyProperty TransitionTypeProperty = DependencyProperty.Register(
        "TransitionType",
        typeof(PageTransitionType),
        typeof(PageTransition),
        new PropertyMetadata(PageTransitionType.SlideAndFade));

    /// <summary>
    /// The pages.
    /// </summary>
    private readonly Stack<UserControl> pages = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="PageTransition"/> class.
    /// </summary>
    public PageTransition()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Gets or sets the transition type.
    /// </summary>
    public PageTransitionType TransitionType
    {
        private get
        {
            return (PageTransitionType)this.GetValue(TransitionTypeProperty);
        }

        set
        {
            this.SetValue(TransitionTypeProperty, value);
        }
    }

    /// <summary>
    /// Shows the page.
    /// </summary>
    /// <param name="newPage">The new page.</param>
    public void ShowPage(UserControl newPage)
    {
        this.pages.Push(newPage);
        Task.Factory.StartNew(this.ShowNewPage);
    }

    /// <summary>
    /// Shows the new page.
    /// </summary>
    private void ShowNewPage()
    {
        this.Dispatcher.Invoke(delegate
        {
            if (this.ContentPresenter.Content != null)
            {
                if (this.ContentPresenter.Content is not UserControl oldPage)
                {
                    return;
                }

                oldPage.Loaded -= this.NewPageLoaded;
                this.UnloadPage();
            }
            else
            {
                this.ShowNextPage();
            }
        });
    }

    /// <summary>
    /// Shows the next page.
    /// </summary>
    private void ShowNextPage()
    {
        var newPage = this.pages.Pop();
        newPage.Loaded += this.NewPageLoaded;
        this.ContentPresenter.Content = newPage;
    }

    /// <summary>
    /// Unloads the page.
    /// </summary>
    private void UnloadPage()
    {
        if (this.Resources[$"{this.TransitionType}Out"] is not Storyboard storyboard)
        {
            return;
        }

        var hidePage = storyboard.Clone();
        hidePage.Completed += this.HidePageCompleted!;
        hidePage.Begin(this.ContentPresenter);
    }

    /// <summary>
    /// Handles the new page loaded event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void NewPageLoaded(object sender, RoutedEventArgs e)
    {
        var showNewPage = this.Resources[$"{this.TransitionType}In"] as Storyboard;
        showNewPage?.Begin(this.ContentPresenter);
    }

    /// <summary>
    /// Handles the hide page completed event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void HidePageCompleted(object sender, EventArgs e)
    {
        this.ContentPresenter.Content = null;
        this.ShowNextPage();
    }
}
