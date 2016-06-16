using System.Windows;
using WebPosts.ViewModel;

namespace WebPosts.View
{
    /// <summary>
    /// Interaction logic for DisplayWebPosts.xaml
    /// </summary>
    public partial class WebPostsView : Window
    {
        public WebPostsView()
        {
            InitializeComponent();
            this.DataContext = new WebpostsViewModel();
        }
    }
}
