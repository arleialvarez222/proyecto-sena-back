﻿using System.ComponentModel.DataAnnotations;

namespace Sena.core.DTO
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public string clientURI { get; set; }
    }
}
