using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Assignment
{
    public class AssignmentDetail
    {
        [Display(Name = "Assignment Id")]
        public int AssignmentId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Due Date")]
        public DateTimeOffset DueDate { get; set; }

        [Display(Name = "Student")]
        public string Student { get; set; }

        [Display(Name = "Course")]
        public string Course { get; set; }

        public decimal Grade { get; set; }

    }
}
