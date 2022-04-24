using System.ComponentModel.DataAnnotations;
namespace E_Learning.ModelManageUser.Teacher
{
    public class LoginTeacher
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
