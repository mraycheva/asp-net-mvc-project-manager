using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Projects
{
    public class IndexM
    {
        public int Page { get; set; }
        public int PagesCount { get; set; }
        public int ItemsPerPage { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        
        public List<Project> Items { get; set; }
    }
}