using System;
using System.Collections.Generic;
using HomeWork.Models;
using HomeWork.Repository;

namespace HomeWork.Service
{
    public class GenresService : IGenresService
    {

        private readonly IGenresRepository _iGenresRepository;

        public GenresService(IGenresRepository iGenresRepository)
        {
            _iGenresRepository = iGenresRepository;
        }

        public void Dispose()
        {
            _iGenresRepository.Dispose();
        }

        public Genres GetById(int id)
        {
            return _iGenresRepository.GetById(id);
        }

        public void Add(Genres genre)
        {
            _iGenresRepository.Add(genre);
        }

        public void Update(Genres genre)
        {
            _iGenresRepository.Update(genre);
        }

        public void Delete(Genres genre)
        {
            _iGenresRepository.Delete(genre);
        }

        public void Delete(int id)
        {
            Genres genre = _iGenresRepository.GetById(id);
            _iGenresRepository.Delete(genre);
        }

        public IEnumerable<Genres> GetAll()
        {
            return _iGenresRepository.GetAll();
        }

        public IEnumerable<Genres> GetByLambdaExpression(Func<Genres, bool> lambda)
        {
            return _iGenresRepository.GetByLambdaExpression(lambda);
        }
    }
}