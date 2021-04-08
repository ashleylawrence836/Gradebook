using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models.Grade
{
    public class GradeListItem
    {
        public int GradeId { get; set; }

        [Display(Name="Grade")]
        public decimal Score { get; set; }
    }
}
