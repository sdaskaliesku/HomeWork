using System.Collections.Generic;
using HomeWork.Models;
using HomeWork.Repository;

namespace HomeWork.Service
{
    public class ActorsService : IActorsService
    {

        private readonly IActorsRepository _iActorsRepository;

        public ActorsService(IActorsRepository iActorsRepository)
        {
            _iActorsRepository = iActorsRepository;
        }

        public void Dispose()
        {
            _iActorsRepository.Dispose();
        }

        public Actors GetById(int id)
        {
            return _iActorsRepository.GetById(id);
        }

        public void Add(Actors actor)
        {
            _iActorsRepository.Add(actor);
        }

        public void Update(Actors actor)
        {
            _iActorsRepository.Update(actor);
        }

        public void Delete(Actors actor)
        {
            _iActorsRepository.Delete(actor);
        }

        public IEnumerable<Actors> GetAll()
        {
            return _iActorsRepository.GetAll();
        }

        public IEnumerable<Actors> GetAllActors(Movies movies)
        {
            return _iActorsRepository.GetAllActors(movies);
        }
    }
}