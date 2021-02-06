using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Reply : Comment
    {
        [Key]
        public int ReplyID { get; set; }

        //[ForeignKey(nameof(Comment))]
        public virtual Comment Comment { get; set; }
    }
}
