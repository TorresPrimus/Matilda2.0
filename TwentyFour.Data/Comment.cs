using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey(nameof(Author))]
        public Guid AuthorID { get; set; }
        public virtual User Author { get; set; }
        [ForeignKey(nameof(CommentPost))]
        public int CommentPostID { get; set; }
        public virtual Post CommentPost { get; set; }
    }
}
