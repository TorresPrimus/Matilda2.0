﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class CommentDetail
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        public string Reply { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
