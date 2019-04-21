using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Users
{
    public class EditM
    {
        public int Id { get; set; }

        // Username
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        // Password
        [DisplayName("Password: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

        // FirstName
        [DisplayName("First name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string FirstName { get; set; }

        // LastName
        [DisplayName("Last name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string LastName { get; set; }
    }
}
