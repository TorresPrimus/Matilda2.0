using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;

namespace TwentyFour.Models
{
    public class LikeDetail
    {
        public int LikePostID { get; set; }
        public virtual Post LikedPost { get; set; }
        public Guid LikerID { get; set; }
    }
}
