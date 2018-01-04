using Prism.Unity;
using Microsoft.Practices.Unity;
using SQLite;
using Acr.UserDialogs;
using Acr.Settings;
using ArcTouch.TestApp.Views;
using System.Net.Http;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcTouch.TestApp
{
    public class App : PrismApplication
    {
        public static SQLiteConnection AppSQLiteConnection { get; set; }
        public static HttpClient AppHttpClient { get; set; }
        public static bool DisableDatabaseOperations { get; set; } = false;
        public static bool IsEmulatingAndroid { get; set; } = true;

        protected override void OnInitialized()
        {
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));
            MobileCenter.LogLevel = LogLevel.Verbose;
            Analytics.Enabled = true;

            // Select the initial page per platform, cause Lottie is unstable at Android yet.
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
                NavigationService.NavigateAsync("BaseNavigationPage/UpcomingMoviePage");
            else
                NavigationService.NavigateAsync("BlankPage");
        }

        protected override void RegisterTypes()
        {
            // Register Interfaces for IoC
            Container.RegisterInstance(UserDialogs.Instance);
            Container.RegisterInstance(Settings.Current);

            Container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Container.RegisterType(typeof(IApplicationServices<>), typeof(ApplicationServices<>));
            Container.RegisterType(typeof(IDefaultSettings), typeof(DefaultSettings));
            Container.RegisterType(typeof(IUIFunctions), typeof(UIFunctions));
            Container.RegisterType(typeof(IStringOperations), typeof(IStringOperations));
            Container.RegisterType(typeof(IMobileCenterCrashes), typeof(MobileCenterCrashes));
            Container.RegisterType(typeof(IMobileAnalyticsFunctions), typeof(MobileAnalyticsFunctions));
            Container.RegisterType(typeof(IMovieApplicationServices), typeof(MovieApplicationServices));
            Container.RegisterType(typeof(IConnectivityFunctions), typeof(ConnectivityFunctions));

            // Register Pages for Navigation System (PRISM)
            Container.RegisterTypeForNavigation<UpcomingMoviePage>();
            Container.RegisterTypeForNavigation<MovieSelectionPage>();
            Container.RegisterTypeForNavigation<BaseNavigationPage>();
            Container.RegisterTypeForNavigation<BlankPage>();
        }
    }
}