using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectManager.Repos
{
    public class PMDbContext : DbContext
    {
        // Users
        public DbSet<User> Users { get; set; }
        // Projects
        public DbSet<Project> Projects { get; set; }

        // Connection to database and DbSets initialisation.
        public PMDbContext()
            : base(@"Server=localhost;Database=ProjectManagerDb;Trusted_Connection=True;")
        {
            Users = Set<User>();
            Projects = Set<Project>();
        }
    }
}