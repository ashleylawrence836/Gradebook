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

        public string Name { get; set; }

        [Display(Name = "Preferred Name")]
        public string Nickname { get; set; }
        public int CourseId { get; set; }
    }
}
