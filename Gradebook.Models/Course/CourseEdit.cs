using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Course
{
    public class CourseEdit
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }
    }
}
