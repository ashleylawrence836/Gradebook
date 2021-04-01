﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    public class GradeListItem
    {
        public int GradeId { get; set; }

        [Display(Name = "Grade")]
        public decimal Score { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int AssignmentId { get; set; }
    }
}