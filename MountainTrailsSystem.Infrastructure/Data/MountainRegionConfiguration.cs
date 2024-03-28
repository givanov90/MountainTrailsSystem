using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data
{
    public class MountainRegionConfiguration : IEntityTypeConfiguration<MountainRegion>
    {
        public void Configure(EntityTypeBuilder<MountainRegion> builder)
        {
            builder.HasKey(mr => new { mr.RegionId, mr.MountainId });

            builder.HasOne(mr => mr.Region)
                .WithMany(r => r.Mountains)
                .HasForeignKey(mr => mr.RegionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mr => mr.Mountain)
                .WithMany(m => m.Regions)
                .HasForeignKey(mr => mr.MountainId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
