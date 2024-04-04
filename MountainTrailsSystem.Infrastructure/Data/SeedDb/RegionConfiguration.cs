using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data.SeedDb
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            var data = new SeedData();

            builder.HasData(new Region[] 
            { 
                data.SofiaRegion,
                data.BlagoevgradRegion,
                data.KyustendilRegion,
                data.PazardjikRegion,
                data.SmolyanRegion,
                data.KardzhaliRegion
            });
        }
    }
}
