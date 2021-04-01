using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [MinLength(2)]
        public string Nickname { get; set; }
    }
}
