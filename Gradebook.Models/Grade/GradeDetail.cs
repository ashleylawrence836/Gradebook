using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Grade
{
    public class GradeDetail
    {
        public int GradeId { get; set; }

        [Display(Name ="Grade")]
        public decimal Score { get; set; }

        [Display(Name = "Assignment Id")]
        public int AssignmentId { get; set; }

        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        public string Student { get; set; }
        public string Course { get; set; }

    }
}
