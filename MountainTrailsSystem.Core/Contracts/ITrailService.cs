using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface ITrailService
    {
        Task<IEnumerable<TrailOverviewServiceModel>> LastThreeTrailsAsync();

        Task<TrailQueryServiceModel> AllTrailsAsync(int currentPage);
    }
}
