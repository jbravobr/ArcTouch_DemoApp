using Xamarin.Forms;

namespace ArcTouch.TestApp.Views
{
    public partial class BaseNavigationPage : NavigationPage
    {
        public BaseNavigationPage(Page page) : base(page)
        {
            InitializeComponent();
        }
    }
}