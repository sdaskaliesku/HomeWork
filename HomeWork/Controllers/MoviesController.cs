using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public ActionResult Create(Movies movie)
        {
            try
            {
                _iMoviesService.Add(movie);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            return Json(movie, JsonRequestBehavior.AllowGet);
        }

        public string Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Movies> movies = _iMoviesService.GetAll();
            return JsonConvert.SerializeObject(movies, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public ActionResult Update(Movies movie)
        {
            try
            {
                _iMoviesService.Update(movie);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            return Json(movie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Destroy(Movies movie)
        {
            try
            {
                _iMoviesService.Delete(movie);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            return Json(movie, JsonRequestBehavior.AllowGet);
        }
    }
}
