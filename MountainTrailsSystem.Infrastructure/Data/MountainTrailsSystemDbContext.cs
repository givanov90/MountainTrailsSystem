using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Infrastructure.Data.SeedDb;

namespace MountainTrailsSystem.Infrastructure.Data
{
    public class MountainTrailsSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public MountainTrailsSystemDbContext(DbContextOptions<MountainTrailsSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new MountainConfiguration());
            builder.ApplyConfiguration(new MountainRegionConfiguration());
            builder.ApplyConfiguration(new PeakConfiguration());
            builder.ApplyConfiguration(new TrailConfiguration());
            builder.ApplyConfiguration(new TrailPeakConfiguration());
            builder.ApplyConfiguration(new UserTrailConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Mountain> Mountains { get; set; }

        public DbSet<Peak> Peaks { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Trail> Trails { get; set; }

        public DbSet<TrailPeak> TrailsPeaks { get; set; }

        public DbSet<MountainRegion> MountainsRegions { get; set; }

        public DbSet<TrailStatusNote> TrailStatusNotes { get; set; }

        public DbSet<UserTrail> UsersTrails { get; set; }
    }
}