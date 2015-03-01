using ScrumChores.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ScrumChores.Business.Context
{
    public class ScrumChoresDbContext : DbContext
    {
        public ScrumChoresDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<SprintTask> Tasks { get; set; } 
    }
}
