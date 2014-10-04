using System.Collections.Generic;

namespace HomeWork.Models
{

    public class Movies
    {
        public Movies()
        {
            Actors = new HashSet<Actors>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime Year { get; set; }
        public int DurationInSeconds { get; set; }
        public int GenreId { get; set; }

        public virtual Genres Genres { get; set; }
        public virtual ICollection<Actors> Actors { get; set; }

        public override string ToString()
        {
            return "[ Id = " + Id
                + ", Title = " + Title
                + ", Year = " + Year
                + ", DurationInSeconds = " + DurationInSeconds
                + " ]";
        }
    }
}