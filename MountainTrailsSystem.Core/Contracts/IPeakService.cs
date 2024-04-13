using MountainTrailsSystem.Core.Enumerations;
using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface IPeakService
    {
        Task CreatePeakAsync(CreatePeakFormModel model);

        Task<bool> PeakExistsAsync(int peakId);

        Task<PeakQueryServiceModel> AllPeaksAsync(int currentPage);

        Task<IEnumerable<PeakServiceModel>> AllPeaksAsListAsync();

        Task<PeakDetailsViewModel> PeakDetailsByIdAsync(int peakId);

        Task<IEnumerable<TrailByPeakServiceModel>> AllTrailsByPeakIdAsync(int peakId, TrailSortCriteria? sortCriteria);

        Task<IEnumerable<PeakOverviewServiceModel>> FindPeaksByConditionAsync(string condition);
    }
}
