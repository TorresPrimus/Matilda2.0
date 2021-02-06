using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class ReplyListItem
    {
        public int CommentID { get; set; }
        public int ReplyID { get; set; }
        public string PostTitle { get; set; }
    }
}
