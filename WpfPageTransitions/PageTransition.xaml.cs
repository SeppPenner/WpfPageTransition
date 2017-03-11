using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfPageTransitions
{
    public partial class PageTransition
    {
        public static readonly DependencyProperty TransitionTypeProperty = DependencyProperty.Register("TransitionType",
            typeof(PageTransitionType),
            typeof(PageTransition), new PropertyMetadata(PageTransitionType.SlideAndFade));

        private readonly Stack<UserControl> _pages = new Stack<UserControl>();

        public PageTransition()
        {
            InitializeComponent();
        }

        public PageTransitionType TransitionType
        {
            private get { return (PageTransitionType) GetValue(TransitionTypeProperty); }
            set { SetValue(TransitionTypeProperty, value); }
        }

        public void ShowPage(UserControl newPage)
        {
            _pages.Push(newPage);
            Task.Factory.StartNew(ShowNewPage);
        }

        private void ShowNewPage()
        {
            Dispatcher.Invoke((Action) delegate
            {
                if (ContentPresenter.Content != null)
                {
                    var oldPage = ContentPresenter.Content as UserControl;
                    if (oldPage == null) return;
                    oldPage.Loaded -= newPage_Loaded;
                    UnloadPage();
                }
                else
                {
                    ShowNextPage();
                }
            });
        }

        private void ShowNextPage()
        {
            var newPage = _pages.Pop();
            newPage.Loaded += newPage_Loaded;
            ContentPresenter.Content = newPage;
        }

        private void UnloadPage()
        {
            var storyboard = Resources[$"{TransitionType}Out"] as Storyboard;
            if (storyboard == null) return;
            var hidePage = storyboard.Clone();
            hidePage.Completed += hidePage_Completed;
            hidePage.Begin(ContentPresenter);
        }

        private void newPage_Loaded(object sender, RoutedEventArgs e)
        {
            var showNewPage = Resources[$"{TransitionType}In"] as Storyboard;
            showNewPage?.Begin(ContentPresenter);
        }

        private void hidePage_Completed(object sender, EventArgs e)
        {
            ContentPresenter.Content = null;
            ShowNextPage();
        }
    }
}