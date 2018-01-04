using Prism.Mvvm;
using System;
using Xamarin.Forms;
using Prism.Navigation;

namespace ArcTouch.TestApp.ViewModels
{
    public class BlankPageViewModel : BindableBase
    {
        readonly INavigationService _navigationService;

        public BlankPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            WaitAnimation();
        }

        /// <summary>
        /// Waits the animation.
        /// </summary>
        void WaitAnimation()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
             {
                 _navigationService.NavigateAsync("BaseNavigationPage/UpcomingMoviePage");
                 return false;
             });
        }
    }
}