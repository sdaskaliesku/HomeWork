using System.Collections.Generic;
using System.Web.Http;
using HomeWork.Models;
using HomeWork.Repository;

namespace HomeWork.Controllers.API
{
    public class GenresController : ApiController
    {

        readonly IGenresRepository _iRepository;

        public GenresController() { }

        public GenresController(IGenresRepository iRepository)
        {
            _iRepository = iRepository;
        }

        // GET api/genres
        public List<Genres> Get()
        {
            return (List<Genres>) _iRepository.GetAll();
        }

        // GET api/genres?id=1
        public Genres Get([FromUri] int id)
        {
            return _iRepository.GetById(id);
        }

    }
}