using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Grade
{
    public class GradeCreate
    {
        [Required]
        [Display(Name="Grade")]
        [Range(0,100, ErrorMessage ="Extra credit not currently available.")]
        public decimal Score { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "Assignment")]
        public int AssignmentId { get; set; }
    }
}
