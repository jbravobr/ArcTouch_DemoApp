using System.Collections.Generic;

namespace ArcTouch.TestApp
{
    public interface IMovieApplicationServices
    {
        List<Results> AssociateGenresWithMovies(List<Results> movies);
    }
}