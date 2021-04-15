using Gradebook.Models.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Assignment
{
    public class AssignmentEdit
    {
        public int AssignmentId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset DueDate { get; set; }

        [Display(Name = "Course")]
        public int? CourseId { get; set; }
        //public IEnumerable<CourseListItem> CourseList { get; set; }

    }
}
