using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAngularApp.Models
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Depatsments { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
    
    }
}