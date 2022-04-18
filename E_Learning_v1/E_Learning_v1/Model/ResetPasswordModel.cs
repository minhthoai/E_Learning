using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm new password is required")]
        public string ConfirmNewPassword { get; set; }
       // public string Token { get; set; }
    }
}
