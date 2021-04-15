using Gradebook.Models.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Student
{
    public class StudentDetail
    {
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Preferred Name")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Nickname { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            { return (FirstName + " " + LastName); }

        }

    }
}
