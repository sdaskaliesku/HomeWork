using System.Collections.Generic;

namespace HomeWork.Models
{
    public class Genres
    {
        public Genres()
        {
            MoviesList = new List<Movies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movies> MoviesList { get; set; }

        public override string ToString()
        {
            return "[ Id = " + Id + ", Name = " + Name + " ]";
        }
    }
}