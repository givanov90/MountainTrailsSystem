using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data.SeedDb
{
    public class PeakConfiguration : IEntityTypeConfiguration<Peak>
    {
        public void Configure(EntityTypeBuilder<Peak> builder)
        {
            var data = new SeedData();

            builder.HasData(new Peak[] 
            { 
                data.OstretsPeak,
                data.MalyovitsaPeak,
                data.KamenitzaPeak,
                data.CherniVrahPeak
            }); 
        }
    }
}
