using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Mvc;
using HomeWork.Models;
using HomeWork.Service;
using Kendo.Mvc.UI;

namespace HomeWork.Controllers
{
    public class GenresController : Controller, ICrudController<Genres>
    {
        private readonly IGenresService _iGenresService;

        public GenresController(IGenresService iGenresService)
        {
            _iGenresService = iGenresService;
        }

        public ActionResult Create(Genres genre)
        {
            string result = "error";
            try
            {
                _iGenresService.Add(genre);
                result = "success";
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
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Genres> genres = _iGenresService.GetAll();
            return Json(genres, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Genres genre)
        {
            string result = "error";
            try
            {
                _iGenresService.Update(genre);
                result = "success";
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
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Destroy(Genres genre)
        {
            string result = "error";
            try
            {
                _iGenresService.Delete(genre);
                result = "success";
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
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
