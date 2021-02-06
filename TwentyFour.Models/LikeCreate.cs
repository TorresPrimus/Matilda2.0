using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class LikeCreate
    {
        [Required]
        public int LikePostID { get; set; }
        //[Required]
        //public Guid LikerID { get; set; }

    }
}
