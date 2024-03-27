using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data
{
    public class TrailConfiguration : IEntityTypeConfiguration<Trail>
    {
        public void Configure(EntityTypeBuilder<Trail> builder)
        {
            builder.HasOne(t => t.Region)
                .WithMany()
                .HasForeignKey(t => t.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
