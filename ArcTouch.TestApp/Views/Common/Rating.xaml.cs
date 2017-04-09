using Xamarin.Forms;

namespace ArcTouch.TestApp.Views.Common
{
    public partial class Rating : ContentView
    {
        public static readonly BindableProperty RatingValueProperty = BindableProperty.Create("RatingValue",
                                                                            typeof(double),
                                                                            typeof(Rating),
                                                                            default(double));
        public double RatingValue
        {
            get { return (double)GetValue(RatingValueProperty); }
            set { SetValue(RatingValueProperty, value); }
        }
    }
}