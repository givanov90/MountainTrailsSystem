using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.StatusNote;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Core.Services
{
    public class StatusNoteService : IStatusNoteService
    {
        private readonly MountainTrailsSystemDbContext data;

        public StatusNoteService(MountainTrailsSystemDbContext _data)
        {
            data = _data;
        }

        public async Task CreateStatusNoteAsync(TrailStatusNoteViewModel model)
        {
            var statusNote = new TrailStatusNote()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                TrailId = model.TrailId,
                IsResolved = false
            };

            await data.TrailStatusNotes.AddAsync(statusNote);
            await data.SaveChangesAsync();
        }

        public async Task<bool> IsStatusNotesNotResolvedAsync()
        {
            return await data.TrailStatusNotes
                .AnyAsync(sn => sn.IsResolved == false);
        }

        public async Task<int> GetNotResolvedStatusNotesCountAsync()
        {
            return await data.TrailStatusNotes
                .Where(sn => sn.IsResolved == false)
                .CountAsync();
        }

        public async Task<IEnumerable<TrailStatusNoteOverviewServiceModel>> AllStatusNotesAsListAsync()
        {
            return await data.TrailStatusNotes
                .Where(sn => sn.IsResolved == false)
                .Select(sn => new TrailStatusNoteOverviewServiceModel()
                {
                    TrailStatusNoteId = sn.TrailStatusNoteId,
                    Title = sn.Title,
                    ImageUrl = sn.ImageUrl,
                    Trail = sn.Trail.Name
                })
                .ToListAsync();
        }

        public async Task<StatusNoteDetailsViewModel> StatusNoteDetailsByIdAsync(int trailStatusNoteId)
        {
            return await data.TrailStatusNotes
                .Where(sn => sn.TrailStatusNoteId == trailStatusNoteId)
                .Select(sn => new StatusNoteDetailsViewModel()
                {
                    TrailStatusNoteId = trailStatusNoteId,
                    Title = sn.Title,
                    Description = sn.Description,
                    ImageUrl = sn.ImageUrl,
                    Trail = sn.Trail.Name,
                    TrailId = sn.Trail.TrailId
                })
                .FirstAsync();
        }

        public async Task ResolveStatusNoteAsync(int trailStatusNoteId)
        {
            var statusNote = await data.TrailStatusNotes
                .Where(sn => sn.TrailStatusNoteId == trailStatusNoteId)
                .FirstAsync();

            statusNote.IsResolved = true;

            await data.SaveChangesAsync();
        }

        public async Task<bool> IsStatusNoteResolvedAsync(int trailStatusNoteId)
        {
            var statusNote = await data.TrailStatusNotes
                .Where(sn => sn.TrailStatusNoteId == trailStatusNoteId)
                .FirstAsync();

            return statusNote.IsResolved;
        }

        public async Task<bool> StatusNoteExistsAsync(int trailStatusNoteId)
        {
            return await data.TrailStatusNotes
                .AnyAsync(sn => sn.TrailStatusNoteId == trailStatusNoteId);
        }

        public async Task<int> GetTrailByStatusNoteIdAsync(int trailStatusNoteId)
        {
            var statusNote = await data.TrailStatusNotes
                .Where(sn => sn.TrailStatusNoteId == trailStatusNoteId)
                .FirstAsync();

            int trailId = statusNote.TrailId;

            return trailId;
        }
    }
}
