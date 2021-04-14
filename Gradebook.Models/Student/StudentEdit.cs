﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Student
{
    public class StudentEdit
    {
        public int StudentId { get; set; }

        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
