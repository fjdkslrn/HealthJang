using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthJang.Models
{
    public class Order
    {
        [Key]
        public int OrderNo { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public int UserNo { get; set; }
    }
}