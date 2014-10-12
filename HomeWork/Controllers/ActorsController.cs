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
    public class ActorsController : Controller, ICrudController<Actors>
    {
        private readonly IActorsService _iActorsService;

        private const string Result = "error";

        public ActorsController(IActorsService iActorsService)
        {
            _iActorsService = iActorsService;
        }

        public String Create(Actors actor)
        {
            try
            {
                _iActorsService.Add(actor);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(actor);
        }

        public String Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Actors> actors = _iActorsService.GetAll();
            return JsonConvert.SerializeObject(actors, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public String Update(Actors actor)
        {
            try
            {
                _iActorsService.Update(actor);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(actor);
        }

        public String Destroy(Actors actor)
        {
            try
            {
                _iActorsService.Delete(actor);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(actor);
        }
    }
}