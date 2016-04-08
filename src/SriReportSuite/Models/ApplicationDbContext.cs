using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using SriReportSuite.Models;

namespace SriReportSuite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Registrar> Registrars { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Study> Studies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
 
    }
}
