using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model.Admin
{
    public class LoginAdmin
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
