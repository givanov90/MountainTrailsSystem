using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data
{
    public class TrailPeakConfiguration : IEntityTypeConfiguration<TrailPeak>
    {
        public void Configure(EntityTypeBuilder<TrailPeak> builder)
        {
            builder.HasKey(tp => new { tp.TrailId, tp.PeakId });

            builder.HasOne(tp => tp.Trail)
                .WithMany(t => t.Peaks)
                .HasForeignKey(tp => tp.TrailId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tp => tp.Peak)
                .WithMany(p => p.Trails)
                .HasForeignKey(tp => tp.PeakId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
