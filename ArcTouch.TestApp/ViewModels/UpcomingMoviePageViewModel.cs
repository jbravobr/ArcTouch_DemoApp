using Prism.Commands;
using System;
using Acr.Settings;
using System.Threading.Tasks;
using PropertyChanged;
using System.Collections.ObjectModel;
using Prism.Navigation;
using System.Linq;
using System.Collections.Generic;

namespace ArcTouch.TestApp.ViewModels
{
    [ImplementPropertyChanged]
    public class UpcomingMoviePageViewModel
    {
        readonly ISettings settingsService;
        readonly IApplicationServices<Results> resultsService;
        readonly IApplicationServices<Genres> genresService;
        readonly IApplicationServices<Images> imagesService;
        readonly IDefaultSettings defaultSettingsService;
        readonly IUIFunctions uiFunctionsService;
        readonly INavigationService _navigationService;
        readonly IMobileAnalyticsFunctions analyticsFunctionsService;
        readonly IMobileCenterCrashes mobileCenterCrashesService;

        public ObservableCollection<Results> Movies { get; set; }
        int Page { get; set; } = 1;
        public string letters { get; set; } = "";
        public DelegateCommand GetMoreItensCommand { get; set; }
        public DelegateCommand<Results> ItemTappedCommand { get; set; }
        public DelegateCommand<string> SearchMovieCommand { get; set; }

        /// <summary>
        /// Gets the search movie.
        /// </summary>
        /// <value>The search movie.</value>
        public Action<string> SearchMovie
        {
            get
            {
                return new Action<string>(async (letter) =>
                {
                    letters = letter;
                    await DoSearchMovie(letter);
                });
            }
        }

        /// <summary>
        /// Does the search movie.
        /// </summary>
        /// <returns>The search movie.</returns>
        /// <param name="letter">Letter.</param>
        async Task DoSearchMovie(string letter)
        {
            if (string.IsNullOrEmpty(letter))
            {
                GetLocalMovieList();
                return;
            }

            var sorted = resultsService.GetAll().Where(x => x.OriginalTitle.ToLowerInvariant().Contains(letter.ToLowerInvariant()))
                               .ToList();
            try
            {
                if (sorted == null || !sorted.Any())
                {
                    sorted = await resultsService
                        .GetAllRemoteData(APIOperations.SearchMovieURLAddres, ConfigureParameters(APIOperations.SearchMovieURLAddres, 1, letter));

                    sorted = AddImageLinkAndRemoveRepeated(sorted);
                }

                Movies = new ObservableCollection<Results>(sorted);
            }
            catch (ConnectionException)
            {
                uiFunctionsService.HideLoading();
                uiFunctionsService.ShowToast(Constants.OfflineMessage, ToastType.Info, 8000);
            }
            catch (FetchRemoteDataException)
            {
                uiFunctionsService.ShowToast(Constants.GetOnlineDataErrorMessage, ToastType.Error, 8000);
                GetLocalMovieList();
            }
            catch
            {
                mobileCenterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GeneralErrorMessage, ToastType.Warning, 8000);
                GetLocalMovieList();
            }
            finally
            {
                analyticsFunctionsService.TrackEvent(AnalitycsEventsName.SearchMovie,
                                                     new Dictionary<string, string> { { letter, sorted.Count.ToString() } });
            }
        }

        /// <summary>
        /// Gets the movie details.
        /// </summary>
        /// <value>The movie details.</value>
        public Action<Results> MovieDetails
        {
            get
            {
                return new Action<Results>(async (Results result) =>
                {
                    var navParams = new NavigationParameters();
                    navParams.Add("MOVIE", result);

                    analyticsFunctionsService.TrackEvent(AnalitycsEventsName.SelectedMovie,
                                                         new Dictionary<string, string> { { result.OriginalTitle, result.Title } });
                    await _navigationService.NavigateAsync("MovieSelectionPage", navParams);
                });
            }
        }

        /// <summary>
        /// Gets the load more itens.
        /// </summary>
        /// <value>The load more itens.</value>
        public Action LoadMoreItens
        {
            get
            {
                return new Action(async () =>
                {
                    if (string.IsNullOrEmpty(letters))
                        await GetMovieListAsync(Page + 1);
                });
            }
        }

        /// <summary>
        /// Gets the local movie list.
        /// </summary>
        void GetLocalMovieList()
        {
            Movies = new ObservableCollection<Results>(resultsService.GetAll().ToList());
        }

        /// <summary>
        /// Gets the movie list.
        /// </summary>
        async void GetMovieList()
        {
            try
            {
                uiFunctionsService.ShowLoading(Constants.MessageLoadingMoviesForTheFirstTime);
                var img = await imagesService.GetRemoteData(APIOperations.Configuration, ConfigureParameters(APIOperations.Configuration));
                if (img != null)
                    settingsService.Set("IMGURL", img.BaseUrl);

                await genresService.GetAllRemoteData(APIOperations.Genres, ConfigureParameters(APIOperations.Genres));

                var ret = await resultsService.GetAllRemoteData(APIOperations.GetMovieListURLAddress, ConfigureParameters(APIOperations.GetMovieListURLAddress));
                ret = AddImageLinkAndRemoveRepeated(ret);

                Movies = new ObservableCollection<Results>(ret);
                uiFunctionsService.HideLoading();
            }
            catch (FetchRemoteDataException)
            {
                uiFunctionsService.HideLoading();
                uiFunctionsService.ShowToast(Constants.GetOnlineDataErrorMessage, ToastType.Error, 8000);
            }
            catch (ConnectionException)
            {
                uiFunctionsService.HideLoading();
                uiFunctionsService.ShowToast(Constants.OfflineMessage, ToastType.Info, 8000);
                GetLocalMovieList();
            }
            catch
            {
                uiFunctionsService.HideLoading();
                mobileCenterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GeneralErrorMessage, ToastType.Error, 8000);
            }
        }

        /// <summary>
        /// Gets the movie list async.
        /// </summary>
        /// <returns>The movie list async.</returns>
        /// <param name="pageIndex">Page index.</param>
        async Task GetMovieListAsync(int pageIndex)
        {
            uiFunctionsService.ShowLoading(Constants.MessageLoadingMoreMovies);

            try
            {
                var ret = await resultsService.GetAllRemoteData(APIOperations.GetMovieListURLAddress, ConfigureParameters(APIOperations.GetMovieListURLAddress, pageIndex));
                ret = AddImageLinkAndRemoveRepeated(ret);
            }
            catch (ConnectionException)
            {
                uiFunctionsService.HideLoading();
                uiFunctionsService.ShowToast(Constants.OfflineMessage, ToastType.Info, 8000);
            }
            catch (FetchRemoteDataException)
            {
                uiFunctionsService.HideLoading();
                uiFunctionsService.ShowToast(Constants.GetOnlineDataErrorMessage, ToastType.Error, 8000);
            }
            catch
            {
                mobileCenterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.HideLoading();
                uiFunctionsService.ShowToast(Constants.GeneralErrorMessage, ToastType.Error, 8000);
            }

            uiFunctionsService.HideLoading();
        }

        /// <summary>
        /// Adds the image link and remove repeated.
        /// </summary>
        /// <returns>The image link and remove repeated.</returns>
        /// <param name="movies">Movies.</param>
        List<Results> AddImageLinkAndRemoveRepeated(List<Results> movies)
        {
            movies.ForEach((obj) =>
                    {
                        if (string.IsNullOrEmpty(obj.FullImagePath) &&
                            !string.IsNullOrEmpty(obj.PosterPath))
                        {
                            obj.FullImagePath = $"{settingsService.Get<string>("IMGURL")}w154{obj.PosterPath}";
                            resultsService.Update(obj);
                        }
                    });

            movies.ForEach((obj) =>
            {
                if (Movies != null && !Movies.Contains(obj))
                    Movies.Add(obj);
            });

            return movies;
        }

        public UpcomingMoviePageViewModel(IApplicationServices<Results> rService,
                                          IApplicationServices<Genres> gService,
                                          IApplicationServices<Images> imgService,
                                          ISettings setSetvices,
                                          IDefaultSettings defSetService,
                                          IUIFunctions uiFuncService,
                                          INavigationService navigationService,
                                          IMobileAnalyticsFunctions analitycFuncService,
                                          IMobileCenterCrashes mbcService)
        {
            _navigationService = navigationService;
            resultsService = rService;
            genresService = gService;
            imagesService = imgService;
            settingsService = setSetvices;
            defaultSettingsService = defSetService;
            uiFunctionsService = uiFuncService;
            analyticsFunctionsService = analitycFuncService;
            mobileCenterCrashesService = mbcService;

            GetMoreItensCommand = new DelegateCommand(LoadMoreItens);
            ItemTappedCommand = new DelegateCommand<Results>((obj) => MovieDetails(obj));
            SearchMovieCommand = new DelegateCommand<string>((obj) => SearchMovie(obj));
            defaultSettingsService.ConfigureInitialSettings();
            GetMovieList();
        }

        /// <summary>
        /// Configures the parameters.
        /// </summary>
        /// <returns>The parameters.</returns>
        /// <param name="operation">Operation.</param>
        /// <param name="page">Page.</param>
        /// <param name="query">Query.</param>
        string ConfigureParameters(APIOperations operation, int page = 1, string query = "")
        {
            switch (operation)
            {
                case APIOperations.GetMovieListURLAddress:
                    return $"api_key={settingsService.Get<string>("APIKEY")}&page={page}";

                case APIOperations.SearchMovieURLAddres:
                    return $"api_key={settingsService.Get<string>("APIKEY")}&query={query}&page={page}";

                case APIOperations.Genres:
                    return $"api_key={settingsService.Get<string>("APIKEY")}";

                case APIOperations.Configuration:
                    return $"api_key={settingsService.Get<string>("APIKEY")}";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}