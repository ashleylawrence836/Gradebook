﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
