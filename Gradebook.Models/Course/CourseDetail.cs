using Gradebook.Models.Assignment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Course
{
    public class CourseDetail
    {
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTimeOffset EndDate { get; set; }

        public List<AssignmentListItem> Assignments { get; set; }
        public decimal Average { get; set; }

    }
}
