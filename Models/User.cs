using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthJang.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required]
        public string UserID { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required]
        public string UserPassword { get; set; }

    }
}