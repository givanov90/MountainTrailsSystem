using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainTrailsSystem.Infrastructure.Data.SeedDb
{
    public class UserTrailConfiguration : IEntityTypeConfiguration<UserTrail>
    {
        public void Configure(EntityTypeBuilder<UserTrail> builder)
        {
            builder.HasKey(ut => new { ut.UserId, ut.TrailId });

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.SavedVisitedTrails)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ut => ut.Trail)
                .WithMany()
                .HasForeignKey(ut => ut.TrailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
