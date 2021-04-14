using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Assignment
{
    public class AssignmentCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "You should come up with a more discriptive assignment name.")]
        public string Name { get; set; }

        [Display(Name ="Due Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset DueDate { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
    }
}
