using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int AssignmentId { get; set; }

        [ForeignKey("AssignmentId")]
        public virtual Assignment Assignment { get; set; }

    }
}
