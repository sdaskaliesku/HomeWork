using System.Collections.Generic;
using System.Web.Http;
using HomeWork.Models;
using HomeWork.Service;

namespace HomeWork.Controllers.API
{
    public class ActorsController : ApiController
    {

        private readonly IActorsService _iActorsService;

        public ActorsController() { }

        public ActorsController(IActorsService iActorsService)
        {
            _iActorsService = iActorsService;
        }

        public List<Actors> Get()
        {
            return (List<Actors>) _iActorsService.GetAll();
        }


        public string Get(int id)
        {
            return _iActorsService.GetById(id).ToString();
        }

    }
}
