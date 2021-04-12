﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Nickname { get; set; }

        //[Required]
        //public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

    }
}
