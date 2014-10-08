using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
            try
            {
                return _db.Movies.Find(id);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return null;
        }

        public void Add(Movies movie)
        {
            try
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public void Update(Movies movie)
        {
            try
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public void Delete(Movies movie)
        {
            try
            {
                Movies movies = _db.Movies.Find(movie.Id);
                _db.Movies.Remove(movies);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public IEnumerable<Movies> GetAll()
        {
            try
            {
                return _db.Movies.ToList();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return null;
        }

        public IEnumerable<Movies> GetByLambdaExpression(Func<Movies, bool> lambda)
        {
            try
            {
                return _db.Movies.Where(lambda).ToList();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return null;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
