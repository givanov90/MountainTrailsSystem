using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface IRegionService
    {
        Task CreateRegionAsync(CreateRegionFormModel model);

        Task<bool> RegionExistsAsync(string regionName);

        Task<IEnumerable<RegionServiceModel>> AllRegionsAsync();
    }
}
