using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace SriReportSuite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Consultant> Consultant { get; set; }
        public DbSet<MRIConsultant> MRIConsultant { get; set; }
        public DbSet<Registrar> Registrar { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Study> Study { get; set; }
        public DbSet<Flow>  Flow { get; set; }
        public DbSet<Measurement> Measurement { get; set;}
        public DbSet<Image> Image { get; set; }
        public DbSet<Volume> Volume { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
 
    }
}
