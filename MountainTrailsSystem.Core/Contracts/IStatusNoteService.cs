using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface IStatusNoteService
    {
        Task CreateStatusNoteAsync(TrailStatusNoteViewModel model);

        Task<bool> IsStatusNotesNotResolvedAsync();

        Task<int> GetNotResolvedStatusNotesCountAsync();

        Task<IEnumerable<TrailStatusNoteOverviewServiceModel>> AllStatusNotesAsListAsync();

        Task<StatusNoteDetailsViewModel> StatusNoteDetailsByIdAsync(int trailStatusNoteId);

        Task ResolveStatusNoteAsync(int trailStatusNoteId);

        Task<bool> StatusNoteExistsAsync(int trailStatusNoteId);

        Task<bool> IsStatusNoteResolvedAsync(int trailStatusNoteId);

        Task<int> GetTrailByStatusNoteIdAsync(int trailStatusNoteId);
    }
}
