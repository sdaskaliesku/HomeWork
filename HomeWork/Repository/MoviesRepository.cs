using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeWork.Context;
using HomeWork.Models;

namespace HomeWork.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly HomeWorkEntitiesContext _db = new HomeWorkEntitiesContext();
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

        public IEnumerable<Movies> GetAllMoviesByGenre(Genres genre)
        {
            return (_db.Movies.Where(m => m.GenreId == genre.Id)).ToList();
        }

        public IEnumerable<Movies> GetAllMoviesByTitle(string title)
        {
            return (_db.Movies.Where(m => m.Title == title)).ToList();
        }

        public IEnumerable<Movies> GetAllMoviesByYear(System.DateTime year)
        {
            return (_db.Movies.Where(m => m.Year == year)).ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}