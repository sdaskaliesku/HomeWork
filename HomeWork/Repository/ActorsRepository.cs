using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _db.Actors.Add(actor);
            _db.SaveChanges();
        }

        public void Update(Actors actor)
        {
            _db.Entry(actor).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Actors actor)
        {
            Actors act = _db.Actors.Find(actor.Id);
            _db.Actors.Remove(act);
            _db.SaveChanges();
        }

        public IEnumerable<Actors> GetAll()
        {
            return _db.Actors.ToList();
        }

        public IEnumerable<Actors> GetByLambdaExpression(Func<Actors, bool> lambda)
        {

            return (_db.Actors.Where(lambda)).ToList();

        }


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
