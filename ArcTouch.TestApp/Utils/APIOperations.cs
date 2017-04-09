namespace ArcTouch.TestApp
{
    public enum APIOperations
    {
        [EnumDescription("search/movie?")]
        SearchMovieURLAddres,

        [EnumDescription("movie/upcoming?")]
        GetMovieListURLAddress,

        [EnumDescription("genre/movie/list?")]
        Genres,

        [EnumDescription("configuration?")]
        Configuration
    }
}