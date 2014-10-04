using System.Collections.Generic;
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
        public List<Genres> Get()
        {
            return (List<Genres>) _iService.GetAll();
        }

        // GET api/genres?id=1
        public Genres Get([FromUri] int id)
        {
            return _iService.GetById(id);
        }

    }
}