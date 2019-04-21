using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Projects
{
    public class EditM
    {
        public int Id { get; set; }

        // Name
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        // Description
        [DisplayName("Description: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

        // Client
        [DisplayName("Client: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Client { get; set; }
    }
}