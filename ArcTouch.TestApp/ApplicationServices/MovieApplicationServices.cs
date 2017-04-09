using System.Collections.Generic;

namespace ArcTouch.TestApp
{
    public class MovieApplicationServices : IMovieApplicationServices
    {
        readonly IUIFunctions uiFunctionsService;
        readonly IMobileCenterCrashes mobileCeterCrashesService;

        public MovieApplicationServices(IUIFunctions uiFunc,
                                        IMobileCenterCrashes mbcService)
        {
            uiFunctionsService = uiFunc;
            mobileCeterCrashesService = mbcService;
        }

        /// <summary>
        /// Associates the genres with movies.
        /// </summary>
        /// <param name="movies">Movies.</param>
        public List<Results> AssociateGenresWithMovies(List<Results> movies)
        {
            try
            {
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Genres == null || movies[i].Genres.Count == 0)
                        movies[i].Genres = new List<Genres>();

                    for (int j = 0; j < movies[i].GenresIds.Count; j++)
                    {
                        if (movies[i].GenresIds[j] <= 0)
                            continue;

                        var genre = App.AppSQLiteConnection.Get<Genres>(movies[i].GenresIds[j]);

                        if (genre == null)
                            movies[i].Genres.Add(new Genres { Id = 999, Name = "Undefined" });
                        else
                            movies[i].Genres.Add(genre as Genres);
                    }
                }

                return movies;
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.AssocieateGenreAndMovieErrorMessage, ToastType.Warning, 3000);
                return new List<Results>();
            }
        }
    }
}