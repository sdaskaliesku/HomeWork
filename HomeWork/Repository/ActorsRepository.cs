using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using HomeWork.Context;
using HomeWork.Models;

namespace HomeWork.Repository
{
    public class ActorsRepository : IActorsRepository
    {
        private readonly HomeWorkEntitiesContext _db;

        public ActorsRepository()
        {
            _db = new HomeWorkEntitiesContext();
        }

        public Actors GetById(int id)
        {
            return _db.Actors.Find(id);
        }

        public void Add(Actors actor)
        {
            try
            {
                _db.Actors.Add(actor);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public void Update(Actors actor)
        {
            try
            {
                _db.Entry(actor).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public void Delete(Actors actor)
        {
            try
            {
                Actors act = _db.Actors.Find(actor.Id);
                _db.Actors.Remove(act);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
        }

        public IEnumerable<Actors> GetAll()
        {
            try
            {
                return _db.Actors.ToList();
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Message: {0} StackTrace: {1}", e.Message, e.StackTrace);
            }
            return null;
        }

        public IEnumerable<Actors> GetByLambdaExpression(Func<Actors, bool> lambda)
        {
            try
            {
                return (_db.Actors.Where(lambda)).ToList();
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
