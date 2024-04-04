using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Infrastructure.Data.SeedDb
{
    public class MountainConfiguration : IEntityTypeConfiguration<Mountain>
    {
        public void Configure(EntityTypeBuilder<Mountain> builder)
        {
            var data = new SeedData();

            builder.HasData(new Mountain[] 
            { 
                data.RilaMountain,
                data.PirinMountain,
                data.VitoshaMountain,
                data.RodopiMountain
            }); 
        }
    }
}
