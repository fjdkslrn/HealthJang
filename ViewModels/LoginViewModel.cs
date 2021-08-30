using System.ComponentModel.DataAnnotations;

namespace HealthJang.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}