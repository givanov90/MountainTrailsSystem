using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface ITrailService
    {
        Task<IEnumerable<TrailOverviewServiceModel>> LastThreeTrailsAsync();

        Task<TrailQueryServiceModel> AllTrailsAsync(int currentPage);

        Task<bool> TrailExistsAsync(int id);

        Task<TrailDetailsViewModel> TrailDetailsByIdAsync(int id);
    }
}
