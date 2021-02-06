using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Reply : Comment
    {
        [ForeignKey(nameof(ReplyComment))]
        public int ReplyCommentID { get; set; }
        public virtual Comment ReplyComment { get; set; }
    }
}
