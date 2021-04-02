using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    public class StudentListItem
    {
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }
        public string Name { get; set; }

    }
}
