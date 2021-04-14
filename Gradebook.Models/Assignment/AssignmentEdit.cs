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
        public int CourseId { get; set; }
    }
}
