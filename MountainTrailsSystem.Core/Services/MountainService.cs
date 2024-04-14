using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.Mountain;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;
using System.Linq;

namespace MountainTrailsSystem.Core.Services
{
    public class MountainService : IMountainService
    {
        private readonly MountainTrailsSystemDbContext data;

        public MountainService(MountainTrailsSystemDbContext _data)
        {
            data = _data;
        }
        public async Task<IEnumerable<MountainServiceModel>> AllMountainsAsync()
        {
            return await data.Mountains
                .Select(m => new MountainServiceModel
                {
                    MountainId = m.Id,
                    Name = m.Name
                })
                .ToListAsync();
        }

        public async Task CreateMountainAsync(CreateMountainFormModel model)
        {
                var mountain = new Mountain()
                {
                     Name = model.Name,
                };

                    await data.Mountains.AddAsync(mountain);
                    await data.SaveChangesAsync();

            foreach (var regionId in model.SelectedRegionIds)
                {
                    var mountainRegion = new MountainRegion()
                        {
                            MountainId = mountain.Id,
                            RegionId = regionId
                    };

                    await data.MountainsRegions.AddAsync(mountainRegion);
                }

                await data.SaveChangesAsync();
        }

        public async Task<bool> MountainExistsAsync(string mountainName)
        {
            return await data.Mountains
                .AnyAsync(m => m.Name == mountainName);
        }
    }
}
