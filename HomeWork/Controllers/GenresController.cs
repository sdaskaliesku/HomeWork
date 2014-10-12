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
    public class GenresController : Controller, ICrudController<Genres>
    {
        private readonly IGenresService _iGenresService;

        private const string Result = "error";
        public GenresController(IGenresService iGenresService)
        {
            _iGenresService = iGenresService;
        }

        public String Create(Genres genre)
        {
            try
            {
                _iGenresService.Add(genre);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(genre);
        }

        public String Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Genres> genres = _iGenresService.GetAll();
            return JsonConvert.SerializeObject(genres, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public String Update(Genres genre)
        {
            try
            {
                _iGenresService.Update(genre);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(genre);
        }

        public String Destroy(Genres genre)
        {
            try
            {
                _iGenresService.Delete(genre);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
                return JsonConvert.SerializeObject(Result);
            }
            return JsonConvert.SerializeObject(genre);
        }
    }
}
