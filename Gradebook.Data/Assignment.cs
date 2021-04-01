using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You should come up with a more discriptive assignment name.")]
        public string Name { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
