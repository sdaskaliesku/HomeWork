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
            _iMoviesRepository = iMoviesRepository;
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

        public void Delete(int id)
        {
            Movies movie = _iMoviesRepository.GetById(id);
            _iMoviesRepository.Delete(movie);
        }

        public IEnumerable<Movies> GetAll()
        {
            return _iMoviesRepository.GetAll();
        }

        public IEnumerable<Movies> GetByLambdaExpression(Func<Movies, bool> lambda)
        {
            return _iMoviesRepository.GetByLambdaExpression(lambda);
        }

        public IEnumerable<Movies> GetAllMoviesByGenre(string genre)
        {
            Func<Movies, bool> lambda = m => m.Genre.Name.ToUpper().Equals(genre.ToUpper());
            return _iMoviesRepository.GetByLambdaExpression(lambda);
        }

        public IEnumerable<Movies> GetAllMoviesByTitle(string title)
        {
            Func<Movies, bool> lambda = m => m.Title == title;
            return _iMoviesRepository.GetByLambdaExpression(lambda);
        }

        public IEnumerable<Movies> GetAllMoviesByYear(int year)
        {
            Func<Movies, bool> lambda = m => m.Year.Year == year;
            return _iMoviesRepository.GetByLambdaExpression(lambda);
        }
    }
}