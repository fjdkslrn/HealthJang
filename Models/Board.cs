using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthJang.Models
{
    public class Board
    {
        [Key]
        public int BoardNo { get; set; }

        [Required]
        public string BoardTitle { get; set; }

        [Required]
        public string BoardContents { get; set; }

        [Required]
        public int UserNo { get; set; }

        public virtual User User { get; set; }
    }
}