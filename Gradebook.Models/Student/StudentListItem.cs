using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    public class StudentListItem
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name ="Preferred Name")]
        [DisplayFormat(NullDisplayText = "N/A")]

        public string Nickname { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            { return (FirstName + " "  + LastName); }

        }

    }
}
