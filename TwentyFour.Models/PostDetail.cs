using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;

namespace TwentyFour.Models
{
    public class PostDetail
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AuthorID { get; set; }
        public virtual User Author { get; set; }
    }
}
