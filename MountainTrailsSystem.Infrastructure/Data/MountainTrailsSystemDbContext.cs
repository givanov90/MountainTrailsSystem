using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data
{
    public class MountainTrailsSystemDbContext : IdentityDbContext
    {
        public MountainTrailsSystemDbContext(DbContextOptions<MountainTrailsSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TrailPeakConfiguration());
            builder.ApplyConfiguration(new TrailConfiguration());
            builder.ApplyConfiguration(new MountainRegionConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Mountain> Mountains { get; set; }

        public DbSet<Peak> Peaks { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Trail> Trails { get; set; }

        public DbSet<TrailPeak> TrailsPeaks { get; set; }

        public DbSet<MountainRegion> MountainsRegions { get; set; }
    }
}