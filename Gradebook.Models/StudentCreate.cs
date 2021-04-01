using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    public class StudentCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Names aren't that short.")]
        [MaxLength(30, ErrorMessage = "Middle names aren't necessary.")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Nicknames aren't that short.")]
        [MaxLength(10, ErrorMessage = "Just stick with their real name")]
        public string Nickname { get; set; }
    }
}
