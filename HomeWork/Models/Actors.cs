using System.Collections.Generic;

namespace HomeWork.Models
{

    public class Actors
    {
        public Actors()
        {
            Movies = new HashSet<Movies>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }

        public override string ToString()
        {
            return "[ Id = " + Id 
                + ", FirstName = " + FirstName
                + ", LastName = " + LastName
                + ", Gender = " + Gender
                + ", DateOfBirth = " + DateOfBirth
                + " ]";
        }
    }
}