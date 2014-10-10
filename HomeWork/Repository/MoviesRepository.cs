using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeWork.Context;
using HomeWork.Models;

namespace HomeWork.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly HomeWorkEntitiesContext _db;

        public MoviesRepository()
        {
            _db = new HomeWorkEntitiesContext();
        }


        public Movies GetById(int id)
        {
            return _db.Movies.Find(id);
        }

        public void Add(Movies movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void Update(Movies movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Movies movie)
        {

            Movies movies = _db.Movies.Find(movie.Id);
            _db.Movies.Remove(movies);
            _db.SaveChanges();

        }

        public IEnumerable<Movies> GetAll()
        {

            return _db.Movies.ToList();

        }

        public IEnumerable<Movies> GetByLambdaExpression(Func<Movies, bool> lambda)
        {

            return _db.Movies.Where(lambda).ToList();

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
