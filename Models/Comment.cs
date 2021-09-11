using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthJang.Models
{
    public class Comment
    {
        [Key]
        public int CommentNo { get; set; }

        [Required]
        public string CommentContents { get; set; }

        [Required]
        public int BoardNo { get; set; }

        public virtual Board Board { get; set; }

        [Required]
        public int UserNo { get; set; }

        public virtual User User { get; set; }
    }
}