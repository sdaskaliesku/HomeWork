using System;
using System.Collections.Generic;
using System.Web.Http;
using HomeWork.Models;
using HomeWork.Service;

namespace HomeWork.Controllers.API
{
    public class MoviesController : ApiController
    {

        private readonly IMoviesService _iMoviesService;

        public MoviesController() { }

        public MoviesController(IMoviesService iMoviesService)
        {
            _iMoviesService = iMoviesService;
        }

        // GET api/movies/
        public List<Movies> Get()
        {
            return (List<Movies>)_iMoviesService.GetAll();
        }

        // GET api/movies?year=2014
        public List<Movies> Get([FromUri] DateTime year)
        {
            return (List<Movies>)_iMoviesService.GetAllMoviesByYear(year);
        }

        // GET api/movies?title=black
        public List<Movies> Get([FromUri] string title)
        {
            return (List<Movies>)_iMoviesService.GetAllMoviesByTitle(title);
        }

        // GET api/movies?genre=action
        public List<Movies> Get([FromUri] Genres genre)
        {
            return (List<Movies>)_iMoviesService.GetAllMoviesByGenre(genre);
        }
    }
}
