using Xamarin.Forms;

namespace ArcTouch.TestApp.Views
{
    public partial class UpcomingMoviePage : ContentPage
    {
        public UpcomingMoviePage()
        {
            InitializeComponent();

            //Disabling Selection
            listViewMovies.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}