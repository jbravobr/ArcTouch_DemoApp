namespace ArcTouch.TestApp
{
    public static class Constants
    {
        public const string BaseURLAddress = "https://api.themoviedb.org/3/";
        public const int ResultPerPage = 20;
        public const string RemoteHostForTestConnection = "https://www.google.com";

        //Messages
        public const string MessageLoadingMoviesForTheFirstTime = "Loading movies ...";
        public const string MessageLoadingMoreMovies = "Loading more movies ...";
        public const string MessageLoadingMovieDetails = "Loading the information about the movie";
        public const string GeneralErrorMessage = "Sorry for the inconvenience, but we are experiencing some problems. Please try again later";
        public const string SaveLocalDataErrorMessage = "Oops ... Error saving data to local storage";
        public const string GetLocalDataErrorMessage = "Oops ... Error retrieving local data";
        public const string DeleteLocalDataErrorMessage = "Oops ... Error removing local data";
        public const string UpdateLocalDataErrorMessage = "Oops ... Error updating local data";
        public const string CreateDatabaseErrorMessage = "Oops ... Error creating database";
        public const string AssocieateGenreAndMovieErrorMessage = "Oops ... Error when trying to discover the movie genre";
        public const string GetOnlineDataErrorMessage = "Oops ... Error trying to fetch information from server. Please try again later";
        public const string LoadingMovieDetailsErrorMessage = "Oops ... Error trying to load information from selected movie";
        public const string LastSessionCrashMessage = "I noticed that there was an error the last time you were here, I apologize and we are reviewing this issue";
        public const string OfflineMessage = "Sorry, in order to perform this action you shold have a active internet connection";
    }
}