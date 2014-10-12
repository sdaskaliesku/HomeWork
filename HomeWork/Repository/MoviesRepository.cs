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

        private const string InsertQuery = @"INSERT INTO [HomeWork.Context.HomeWorkEntitiesContext].[dbo].[MoviesActors] ([MovieId] ,[ActorId]) VALUES ({0} , {1})";
        private const string DeleteQuery = @"DELETE FROM [HomeWork.Context.HomeWorkEntitiesContext].[dbo].[MoviesActors] WHERE [MovieId] = {0}";

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
            var actorsList = movie.ActorsList.Select(actor => _db.Actors.Find(actor.Id)).ToList();
            movie.ActorsList = actorsList;
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void Update(Movies movie)
        {
            /*Trace.TraceInformation("Updating movie!");
            Trace.TraceInformation("\r\nMovie: {0} \r\nActorsList: {1} ", movie, movie.ActorsList.Count);
            foreach (var actor in movie.ActorsList)
            {
                Trace.TraceInformation("\r\nActor: {0}", actor);
            }*/

            var actorsList = new List<Actors>();
            DeleteThirdTable(movie.Id); // deleting all actors from third table
            foreach (var actor in movie.ActorsList)
            {
                actorsList.Add(actor);
                InsertThirdTable(movie.Id, actor.Id); // insert new actor to third table
            }
            movie.ActorsList = actorsList;

            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        private void InsertThirdTable(int movieId, int actorId)
        {
            string query = string.Format(InsertQuery, movieId, actorId);
            _db.Database.ExecuteSqlCommand(query);
        }

        private void DeleteThirdTable(int movieId)
        {
            string query = string.Format(DeleteQuery, movieId);
            _db.Database.ExecuteSqlCommand(query);
        }

        public void Delete(Movies movie)
        {
            int id = movie.Id;
            Movies movies = _db.Movies.Find(id);
            DeleteThirdTable(id);
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
