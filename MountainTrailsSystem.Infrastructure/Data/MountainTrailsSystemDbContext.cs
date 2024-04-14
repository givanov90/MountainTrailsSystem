using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Infrastructure.Data.SeedDb;

namespace MountainTrailsSystem.Infrastructure.Data
{
    public class MountainTrailsSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool seedDb;
        public MountainTrailsSystemDbContext(DbContextOptions<MountainTrailsSystemDbContext> options,
            bool _seed = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            seedDb = _seed;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (seedDb)
            {
                builder.ApplyConfiguration(new ApplicationUserConfiguration());
                builder.ApplyConfiguration(new RegionConfiguration());
                builder.ApplyConfiguration(new MountainConfiguration());
                builder.ApplyConfiguration(new MountainRegionConfiguration());
                builder.ApplyConfiguration(new PeakConfiguration());
                builder.ApplyConfiguration(new TrailConfiguration());
                builder.ApplyConfiguration(new TrailPeakConfiguration());
                builder.ApplyConfiguration(new UserTrailConfiguration());
            }
            else
            {
                builder
                    .Entity<MountainRegion>()
                    .HasKey(mr => new { mr.RegionId, mr.MountainId });

                builder
                    .Entity<MountainRegion>()
                    .HasOne(mr => mr.Region)
                    .WithMany(r => r.Mountains)
                    .HasForeignKey(mr => mr.RegionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .Entity<MountainRegion>()
                    .HasOne(mr => mr.Mountain)
                    .WithMany(m => m.Regions)
                    .HasForeignKey(mr => mr.MountainId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .Entity<Trail>()
                    .HasOne(t => t.Region)
                    .WithMany()
                    .HasForeignKey(t => t.RegionId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .Entity<TrailPeak>()
                    .HasKey(tp => new { tp.TrailId, tp.PeakId });

                builder
                    .Entity<TrailPeak>()
                    .HasOne(tp => tp.Trail)
                    .WithMany(t => t.Peaks)
                    .HasForeignKey(tp => tp.TrailId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .Entity<TrailPeak>()
                    .HasOne(tp => tp.Peak)
                    .WithMany(p => p.Trails)
                    .HasForeignKey(tp => tp.PeakId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .Entity<UserTrail>()
                    .HasKey(ut => new { ut.UserId, ut.TrailId });

                builder
                    .Entity<UserTrail>()
                    .HasOne(ut => ut.User)
                    .WithMany(u => u.SavedVisitedTrails)
                    .HasForeignKey(ut => ut.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .Entity<UserTrail>()
                    .HasOne(ut => ut.Trail)
                    .WithMany()
                    .HasForeignKey(ut => ut.TrailId)
                    .OnDelete(DeleteBehavior.Cascade);
            }

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