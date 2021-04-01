using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public decimal Score { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int AssignmentId { get; set; }
    }
}
