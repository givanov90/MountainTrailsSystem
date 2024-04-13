using MountainTrailsSystem.Core.Models;
using MountainTrailsSystem.Infrastructure.Enumerations;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface ITrailService
    {
        Task<IEnumerable<TrailOverviewServiceModel>> LastThreeTrailsAsync();

        Task<TrailQueryServiceModel> AllTrailsAsync(int currentPage);

        Task<bool> TrailExistsAsync(int id);

        Task<bool> TrailByNameExistsAsync(string trailName);

        Task<TrailDetailsViewModel> TrailDetailsByIdAsync(int trailId);

        Task<IEnumerable<TrailOverviewServiceModel>> AllTrailsByUserIdAsync(string userId);

        Task AddTrailToSavedAsync(string userId, int trailId);

        Task AddTrailToVisitedAsync(string userId, int trailId);

        Task<TrailUpdateFormModel?> GetTrailUpdateFormModelAsync(int trailId);

        Task UpdateAsync(int trailId, TrailUpdateFormModel model);

        Task<bool> IsTrailSavedByUserAsync(string userId, int trailId);

        Task<bool> IsTrailVisitedByUserAsync(string userId, int trailId);

        Task RemoveTrailFromSavedAsync(string userId, int trailId);

        Task<IEnumerable<TrailOverviewServiceModel>> AllSavedTrailsByUserIdAsync(string userId);

        Task<IEnumerable<TrailOverviewServiceModel>> AllVisitedTrailsByUserIdAsync(string userId);

        Task CreateTrailAsync(CreateTrailFormModel model);

        Task<IEnumerable<TrailServiceModel>> AllTrailsAsListAsync();

        Task<IEnumerable<TrailOverviewServiceModel>> FindTrailsByConditionsAsync(int? regionId, DifficultyLevel? difficultyLevel, double? duration, int? elevationGain);
    }
}
