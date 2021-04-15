using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data
{
    public enum Gender { Female, Male, Other, PreferNotToSay}
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string FullName
        {
            get
            { return (FirstName + " " + LastName); }

        }

        public virtual List<Assignment> Assignments { get; set; }
    }
}
