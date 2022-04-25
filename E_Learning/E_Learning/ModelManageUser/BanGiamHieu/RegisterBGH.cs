﻿using System.ComponentModel.DataAnnotations;
namespace E_Learning.ModelManageUser.BanGiamHieu
{
    public class RegisterBGH
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}