using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data.SeedDb
{
    public class TrailConfiguration : IEntityTypeConfiguration<Trail>
    {
        public void Configure(EntityTypeBuilder<Trail> builder)
        {
            builder.HasOne(t => t.Region)
                .WithMany()
                .HasForeignKey(t => t.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Trail[] 
            { 
                data.VelingradOstretsPeakTrail,
                data.SvetaPetkaOstretsPeakTrail,
                data.MalyovitsaHutMalyovitsaPeakTrail,
                data.IvanVazovHutMalyovitsaPeakTrail,
                data.RilaMonasteryMalyovitsaPeakTrail,
                data.TevnoEzeroShelterKamenitzaPeakTrail,
                data.BegovitsaHutKamenitzaPeakTrail,
                data.BezbogHutKamenitzaPeakTrail,
                data.AlekoHutCherniVrahPeakTrail,
                data.ZheleznitsaCherniVrahPeakTrail,
                data.ZlatniteMostoveCherniVrahPeakTrail
            });
        }
    }
}