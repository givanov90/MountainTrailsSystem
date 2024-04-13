using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Core.Services
{
    public class RegionService : IRegionService
    {
        private readonly MountainTrailsSystemDbContext data;

        public RegionService(MountainTrailsSystemDbContext _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<RegionServiceModel>> AllRegionsAsync()
        {
            return await data.Regions
                .Select(m => new RegionServiceModel
                {
                    RegionId = m.RegionId,
                    Name = m.Name
                })
                .ToListAsync();
        }

        public async Task CreateRegionAsync(CreateRegionFormModel model)
        {
            var region = new Region()
            {
                Name = model.Name
            };

            await data.Regions.AddAsync(region);
            await data.SaveChangesAsync();
        }

        public async Task<bool> RegionExistsAsync(string regionName)
        {
            return await data.Regions
                .AnyAsync(r => r.Name == regionName);
        }
    }
}
