using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthJang.Models
{
    public class OrderDetail
    {
        [Key]
        public int MyProperty { get; set; }

        [Required]
        public int OrderNo { get; set; }

        [Required]
        public int ProductNo { get; set; }
    }
}