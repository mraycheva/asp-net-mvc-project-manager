using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Home
{
    public class LoginM
    {
        // Username
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "This is required!")]
        public string Username { get; set; }

        // Password
        [DisplayName("Password: ")]
        [Required(ErrorMessage = "This is required!")]
        public string Password { get; set; }
    }
}