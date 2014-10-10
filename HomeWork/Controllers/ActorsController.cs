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
    public class ActorsController : Controller, ICrudController<Actors>
    {
        private readonly IActorsService _iActorsService;

        private const string Result = "error";

        public ActorsController(IActorsService iActorsService)
        {
            _iActorsService = iActorsService;
        }

        public ActionResult Create(Actors actor)
        {
            try
            {
                _iActorsService.Add(actor);
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
            return Json(actor, JsonRequestBehavior.AllowGet);
        }

        public String Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Actors> actors = _iActorsService.GetAll();
            return JsonConvert.SerializeObject(actors, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public ActionResult Update(Actors actor)
        {
            try
            {
                _iActorsService.Update(actor);
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
            return Json(actor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Destroy(Actors actor)
        {
            try
            {
                /*if (actor.MoviesList.Count > 0)
                {
                    return Json(Result, JsonRequestBehavior.AllowGet);
                }*/
                _iActorsService.Delete(actor);
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
            return Json(actor, JsonRequestBehavior.AllowGet);
        }
    }
}