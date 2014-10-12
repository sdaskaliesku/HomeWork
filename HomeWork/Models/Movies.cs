using System;
using System.Collections.Generic;

namespace HomeWork.Models
{

    public class Movies
    {
        public Movies()
        {
            ActorsList = new List<Actors>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public int DurationInSeconds { get; set; }
        public int GenreId { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual ICollection<Actors> ActorsList { get; set; }
        public override string ToString()
        {
            return "[ Id = " + Id
                   + ", Title = " + Title
                   + ", Year = " + Year
                   + ", DurationInSeconds = " + DurationInSeconds
                   + ", GenreId = " + GenreId
                   + ", Genre = " + Genre +
                   ", ActorsCount = " + ActorsList.Count +
                   " ]";
        }
    }
}