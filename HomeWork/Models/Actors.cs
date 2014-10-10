using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.Models
{
    public class Actors
    {
        public Actors()
        {
            MoviesList = new List<Movies>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public virtual ICollection<Movies> MoviesList { get; set; }
        public override string ToString()
        {
            return "[ Id = " + Id 
                + ", FirstName = " + FirstName
                + ", LastName = " + LastName
                + ", Gender = " + Gender
                + ", DateOfBirth = " + DateOfBirth
                + " ]";
        }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}