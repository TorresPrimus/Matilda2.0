using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;

namespace TwentyFour.Models
{
    public class ReplyDetail : CommentDetail
    {
        //Note this inherits from CommentDetail
        public int ReplyCommentID { get; set; }
        public virtual Comment ReplyComment { get; set; }
    }
}
