﻿using System;
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
        public string Name { get; set; }
        public  string Nickname { get; set; }
        public int CourseId { get; set; }

    }
}
