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
        [MaxLength(8000)]
        public string Text { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
        [Required]
        public int CommentPostID { get; set; }
    }
}
