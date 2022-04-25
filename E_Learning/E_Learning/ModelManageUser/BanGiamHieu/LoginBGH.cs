using System.ComponentModel.DataAnnotations;
namespace E_Learning.ModelManageUser.BanGiamHieu
{
    public class LoginBGH
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
