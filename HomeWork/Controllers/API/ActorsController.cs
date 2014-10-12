using System;
using System.Web.Http;
using HomeWork.Service;
using Newtonsoft.Json;

namespace HomeWork.Controllers.API
{
    public class ActorsController : ApiController
    {

        private readonly IActorsService _iActorsService;

        public ActorsController(IActorsService iActorsService)
        {
            _iActorsService = iActorsService;
        }

        public String Get()
        {
            return JsonConvert.SerializeObject(_iActorsService.GetAll(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }


        public String Get(int id)
        {
            return JsonConvert.SerializeObject(_iActorsService.GetById(id), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        //~/api/actors?lastName=Smith
        public String GetLastName([FromUri] String lastName)
        {
            return JsonConvert.SerializeObject(_iActorsService.GetAllActorsByLastName(lastName), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        //~/api/actors?olderThan=30
        public String GetOlderThan([FromUri] int olderThan)
        {
            return JsonConvert.SerializeObject(_iActorsService.GetAllActorsOlderThen(olderThan), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        //~/api/actors?gender=1
        public String GetGender([FromUri] int gender)
        {
            return JsonConvert.SerializeObject(_iActorsService.GetAllActorsByGender(gender == 1), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

    }
}
