using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using UXDivers.Artina.Shared;

namespace ArcTouch.TestApp.Droid
{
    [Activity(Label = "DemoApp",
              Icon = "@drawable/ic_launcher",
              Theme = "@style/MyTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Microsoft.Azure.Mobile.MobileCenter.Configure("56032f21-e332-42c6-b3a6-ed0b21b2f0ec");

            Acr.UserDialogs.UserDialogs.Init(() => (Activity)Forms.Context); // Initializing Acr.UserDialogs
            FFImageLoading.Forms.Droid.CachedImageRenderer.Init(); // Initializing FFImageLoading

            // Initializing UXDivers.Effects
            FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));
            FormsHelper.ForceLoadingAssemblyContainingType<UXDivers.Effects.Droid.CircleEffect>();

            LoadApplication(new App());
        }
    }
}