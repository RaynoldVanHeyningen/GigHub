using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GigHub.Models;

namespace GigHub.Areas.Identity.Data
{
    public class GigHubIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public GigHubIdentityDbContext(DbContextOptions<GigHubIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Attendance>().HasKey(t => new
            {
                t.GigId,
                t.AttendeeId
            });

            builder.Entity<Attendance>()
                .HasOne(t => t.Gig)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
