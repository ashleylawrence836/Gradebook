﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Grade
{
    public class GradeEdit
    {
        public int GradeId { get; set; }

        [Display(Name ="Grade")]
        public decimal Score { get; set; }

        [Display(Name = "Assignment")]
        public int AssignmentId { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }

    }
}
