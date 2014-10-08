using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HomeWork.Models;
using HomeWork.Service;

namespace HomeWork.Controllers.API
{
    public class GenresController : ApiController
    {

        private readonly IGenresService _iService;

        public GenresController(IGenresService iService)
        {
            this._iService = iService;
        }

        // GET api/genres
        public IEnumerable<Genres> Get()
        {
            return _iService.GetAll();
        }

        public IEnumerable<Genres> Post()
        {
            return _iService.GetAll();
        }

        // GET api/genres?id=1
        public string Get([FromUri] int id)
        {
            return _iService.GetById(id).Name;
        }

    }
}