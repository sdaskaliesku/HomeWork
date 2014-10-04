using System;
using System.Collections.Generic;
using HomeWork.Models;
using HomeWork.Repository;

namespace HomeWork.Service
{
    public class MoviesService : IMoviesService
    {

        private readonly IMoviesRepository _iMoviesRepository;

        public MoviesService(IMoviesRepository iMoviesRepository)
        {
            this._iMoviesRepository = iMoviesRepository;
        }

        public void Dispose()
        {
            _iMoviesRepository.Dispose();
        }

        public Movies GetById(int id)
        {
            return _iMoviesRepository.GetById(id);
        }

        public void Add(Movies movie)
        {
            _iMoviesRepository.Add(movie);
        }

        public void Update(Movies movie)
        {
            _iMoviesRepository.Update(movie);
        }

        public void Delete(Movies movie)
        {
            _iMoviesRepository.Delete(movie);
        }

        public IEnumerable<Movies> GetAll()
        {
            return _iMoviesRepository.GetAll();
        }

        public IEnumerable<Movies> GetAllMoviesByGenre(Genres genre)
        {
            return _iMoviesRepository.GetAllMoviesByGenre(genre);
        }

        public IEnumerable<Movies> GetAllMoviesByTitle(string title)
        {
            return _iMoviesRepository.GetAllMoviesByTitle(title);
        }

        public IEnumerable<Movies> GetAllMoviesByYear(DateTime year)
        {
            return _iMoviesRepository.GetAllMoviesByYear(year);
        }
    }
}