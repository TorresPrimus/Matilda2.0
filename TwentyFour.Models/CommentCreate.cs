using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class CommentCreate
    {
        [Required]
        public int PostID { get; set; }

        [Required, MinLength(2, ErrorMessage = "Please enter at least 2 characters."), MaxLength(8000, ErrorMessage = "Too many characters for this field.")]
        public string Text { get; set; }
    }
}
