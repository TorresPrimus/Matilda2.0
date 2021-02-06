using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Like
    {
        public int ID { get; set; }
        [ForeignKey(nameof(LikedPost))]
        public int LikePostID { get; set; }
        public virtual Post LikedPost { get; set; }
        [ForeignKey(nameof(Liker))]
        public Guid LikerID { get; set; }
        public virtual User Liker { get; set; }
    }
}
