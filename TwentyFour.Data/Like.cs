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
        public int PostID { get; set; }
        public virtual Post LikedPost { get; set; }
        public Guid LikerID { get; set; }
    }
}
