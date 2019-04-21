using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Users
{
    public class IndexM
    {
        public int Page { get; set; }
        public int PagesCount { get; set; }
        public int ItemsPerPage { get; set; }

        // Username
        [DisplayName("Username: ")]
        public string Username { get; set; }

        // FirstName
        [DisplayName("First name: ")]
        public string FirstName { get; set; }
        
        // LastName
        [DisplayName("Last name: ")]
        public string LastName { get; set; }
        
        public List<User> Items { get; set; }
    }
}