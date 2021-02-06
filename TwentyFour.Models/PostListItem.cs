using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class PostListItems
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Guid AuthorID { get; set; }

    }
}
