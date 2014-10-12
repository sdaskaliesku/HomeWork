using System;
using System.Web.Http;
using HomeWork.Models;
using HomeWork.Service;
using Newtonsoft.Json;

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
        public String Get()
        {
            return JsonConvert.SerializeObject(_iMoviesService.GetAll(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

        }

        // GET api/movies?year=2014
        public String GetYear([FromUri] int year)
        {
            return JsonConvert.SerializeObject(_iMoviesService.GetAllMoviesByYear(year), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET api/movies?title=black
        public String GetTitle([FromUri] String title)
        {
            return JsonConvert.SerializeObject(_iMoviesService.GetAllMoviesByTitle(title), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET api/movies?genre=action
        public String GetGenre([FromUri] String genre)
        {
            return JsonConvert.SerializeObject(_iMoviesService.GetAllMoviesByGenre(genre), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
