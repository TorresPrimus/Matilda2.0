using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class CommentListItem
    {
        public int CommentID { get; set; }

        public Guid AuthorID { get; set; }

        public int CommentPostID { get; set; }
    }
}
