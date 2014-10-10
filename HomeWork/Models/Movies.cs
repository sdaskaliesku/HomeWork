using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string DurationString
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:00}", DurationInSeconds / 3600, (DurationInSeconds / 60) % 60, DurationInSeconds % 60);
            }
        }
        public virtual Genres Genre { get; set; }
        public virtual ICollection<Actors> ActorsList { get; set; }
        public override string ToString()
        {
            return "[ Id = " + Id
                   + ", Title = " + Title
                   + ", Year = " + Year
                   + ", DurationInSeconds = " + DurationInSeconds
                   + ", Genre = " + Genre +
                   ", ActorsCount = " + ActorsList.Count +
                   " ]";
        }
    }
}