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
    public class ActorsController : Controller, ICrudController<Actors>
    {
        private readonly IActorsService _iActorsService;

        public ActorsController(IActorsService iActorsService)
        {
            _iActorsService = iActorsService;
        }

        public ActionResult Create(Actors actor)
        {
            string result = "error";
            try
            {
                _iActorsService.Add(actor);
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
            IEnumerable<Actors> actors = _iActorsService.GetAll();
            return Json(actors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Actors actor)
        {
            string result = "error";
            try
            {
                _iActorsService.Add(actor);
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

        public ActionResult Destroy(Actors actor)
        {
            string result = "error";
            try
            {
                _iActorsService.Delete(actor);
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