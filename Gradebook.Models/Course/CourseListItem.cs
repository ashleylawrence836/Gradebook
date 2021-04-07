using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Course
{
    public class CourseListItem
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTimeOffset EndDate { get; set; }
    }
}
