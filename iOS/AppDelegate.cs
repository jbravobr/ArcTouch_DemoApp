using FFImageLoading.Forms.Touch;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using Syncfusion.SfRating.XForms.iOS;
using UIKit;
using UXDivers.Artina.Shared;

namespace ArcTouch.TestApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            new SfRatingRenderer();

            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(255, 131, 0);
            UINavigationBar.Appearance.TintColor = UIColor.White;

            global::Xamarin.Forms.Forms.Init();
            Microsoft.Azure.Mobile.MobileCenter.Configure("515f105a-55ed-44ba-98f5-7db8771d2d40");
            CachedImageRenderer.Init(); // Initializing FFImageLoading
            AnimationViewRenderer.Init(); // Initializing Lottie

            // Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif
            // Initializing UXDivers.Effects
            FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));
            FormsHelper.ForceLoadingAssemblyContainingType<UXDivers.Effects.iOS.CircleEffect>();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}