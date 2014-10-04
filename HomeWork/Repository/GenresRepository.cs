using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeWork.Context;
using HomeWork.Models;

namespace HomeWork.Repository
{
    public class GenresRepository : IGenresRepository
    {
        private readonly HomeWorkEntitiesContext _db = new HomeWorkEntitiesContext();
        public Genres GetById(int id)
        {
            return _db.Genres.Find(id);
        }

        public void Add(Genres genre)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
        }

        public void Update(Genres genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Genres genre)
        {
            Genres genres = _db.Genres.Find(genre.Id);
            _db.Genres.Remove(genres);
            _db.SaveChanges();
        }

        public IEnumerable<Genres> GetAll()
        {
            return _db.Genres.ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}