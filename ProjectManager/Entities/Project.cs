using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
    }
}