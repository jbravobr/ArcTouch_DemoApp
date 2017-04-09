using System;
using Prism.Commands;
using Prism.Navigation;
using PropertyChanged;
using System.Collections.Generic;

namespace ArcTouch.TestApp.ViewModels
{
    [ImplementPropertyChanged]
    public class MovieSelectionPageViewModel : INavigationAware
    {
        public Results Movie { get; set; }
        public DelegateCommand OnMovieTapped { get; set; }

        readonly IUIFunctions uiFunctionsService;
        readonly INavigationService _navigationService;
        readonly IMobileCenterCrashes mobileCenterCrashesService;
        readonly IMobileAnalyticsFunctions analyticsFunctionsService;

        /// <summary>
        /// Gets the play movie.
        /// </summary>
        /// <value>The play movie.</value>
        public Action PlayMovie
        {
            get
            {
                return new Action(() =>
                {
                    analyticsFunctionsService.TrackEvent(AnalitycsEventsName.PlayMovie,
                                                         new Dictionary<string, string> { { Movie.OriginalTitle, Movie.VoteAverage.ToString() } });
                    uiFunctionsService.ShowAlert("You should start playing the movie now");
                });
            }
        }

        public MovieSelectionPageViewModel(IUIFunctions uiFunc,
                                           INavigationService navigationService,
                                           IMobileCenterCrashes mbcService,
                                           IMobileAnalyticsFunctions mafService)
        {
            _navigationService = navigationService;
            uiFunctionsService = uiFunc;
            mobileCenterCrashesService = mbcService;
            analyticsFunctionsService = mafService;

            mobileCenterCrashesService.DidAppCrash();

            OnMovieTapped = new DelegateCommand(PlayMovie);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            uiFunctionsService.ShowLoading("MessageLoadingMovieDetails");

            try
            {
                if (parameters.ContainsKey("MOVIE"))
                    Movie = parameters["MOVIE"] as Results;
            }
            catch
            {
                mobileCenterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.LoadingMovieDetailsErrorMessage, ToastType.Warning, 8000);
                _navigationService.GoBackAsync();
            }

            uiFunctionsService.HideLoading();
        }
    }
}