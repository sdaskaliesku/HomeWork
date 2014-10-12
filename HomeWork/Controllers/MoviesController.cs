using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using HomeWork.Models;
using HomeWork.Service;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace HomeWork.Controllers
{
    public class MoviesController : Controller, ICrudController<Movies>
    {
        private readonly IMoviesService _iMoviesService;
        private const string Result = "error";

        public MoviesController(IMoviesService iMoviesService)
        {
            _iMoviesService = iMoviesService;
        }

        public String Create(Movies movie)
        {
            try
            {
                _iMoviesService.Add(movie);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(movie, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public String Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Movies> movies = _iMoviesService.GetAll();
            return JsonConvert.SerializeObject(movies, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public String Update(Movies movie)
        {
            try
            {
                _iMoviesService.Update(movie);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(movie, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public String Destroy(Movies movie)
        {
            try
            {
                _iMoviesService.Delete(_iMoviesService.GetById(movie.Id));
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(movie, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
