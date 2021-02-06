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
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid Author { get; set; }
        public virtual User AuthorId { get; set; }

        [ForeignKey(nameof(CommentPost))]
        public string CommentPostId { get; set; }
        public virtual Post CommentPost { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
