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
    public class GenresController : Controller, ICrudController<Genres>
    {
        private readonly IGenresService _iGenresService;

        private const string Result = "error";
        public GenresController(IGenresService iGenresService)
        {
            _iGenresService = iGenresService;
        }

        public ActionResult Create(Genres genre)
        {
            try
            {
                _iGenresService.Add(genre);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            return Json(genre, JsonRequestBehavior.AllowGet);
        }

        public string Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Genres> genres = _iGenresService.GetAll();
            return JsonConvert.SerializeObject(genres, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public ActionResult Update(Genres genre)
        {
            try
            {
                _iGenresService.Update(genre);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            return Json(genre, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Destroy(Genres genre)
        {
            try
            {
                _iGenresService.Delete(genre);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            return Json(genre, JsonRequestBehavior.AllowGet);
        }
    }
}
