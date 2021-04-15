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
        [MaxLength(15, ErrorMessage = "Consider using nickname.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Names aren't that short.")]
        [MaxLength(40, ErrorMessage = "Too many characters in this field.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MinLength(2, ErrorMessage = "Nicknames aren't that short.")]
        [MaxLength(10, ErrorMessage = "Just stick with their real name")]
        public string Nickname { get; set; }

    }
}
