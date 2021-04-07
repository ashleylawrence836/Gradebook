using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Course
{
    public class CourseCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "That's not even a real course.")]
        [MaxLength(15, ErrorMessage = "Too many characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }
    }
}
