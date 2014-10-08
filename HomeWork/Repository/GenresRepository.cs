using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using HomeWork.Context;
using HomeWork.Models;

namespace HomeWork.Repository
{
    public class GenresRepository : IGenresRepository
    {
        private readonly HomeWorkEntitiesContext _db;

        public GenresRepository()
        {
            _db = new HomeWorkEntitiesContext();
        }

        public Genres GetById(int id)
        {
            try
            {
                return _db.Genres.Find(id);
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return null;
        }

        public void Add(Genres genre)
        {
            try
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public void Update(Genres genre)
        {
            try
            {
                _db.Entry(genre).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public void Delete(Genres genre)
        {
            try
            {
                Genres genres = _db.Genres.Find(genre.Id);
                _db.Genres.Remove(genres);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public IEnumerable<Genres> GetAll()
        {
            try
            {
                return _db.Genres.ToList();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return null;
        }

        public IEnumerable<Genres> GetByLambdaExpression(Func<Genres, bool> lambda)
        {
            try
            {
                return _db.Genres.Where(lambda).ToList();
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
