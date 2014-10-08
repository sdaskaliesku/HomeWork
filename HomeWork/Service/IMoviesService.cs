using System;
using System.Collections.Generic;
using HomeWork.Models;

namespace HomeWork.Service
{
    public interface IMoviesService : IService<Movies>
    {
        IEnumerable<Movies> GetAllMoviesByGenre(Genres genre);
        IEnumerable<Movies> GetAllMoviesByTitle(String title);
        IEnumerable<Movies> GetAllMoviesByYear(DateTime year);
    }
}
