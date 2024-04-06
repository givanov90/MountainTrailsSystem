using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Core.Services
{
    public class TrailService : ITrailService
    {
        private readonly MountainTrailsSystemDbContext data;

        public TrailService(MountainTrailsSystemDbContext _data)
        {
            data = _data;
        }

        public async Task<TrailQueryServiceModel> AllTrailsAsync(int currentPage = 1)
        {
            var trailsQuery = data.Trails.AsQueryable();

            var trails = await trailsQuery
                .Skip((currentPage - 1) * 3)
                .Take(3)
                .Select(t => new TrailOverviewServiceModel
                {
                    TrailId = t.TrailId,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Distance = t.Distance,
                    DifficultyLevel = t.DifficultyLevel
                })
                .ToListAsync();


            int totalTrails = await trailsQuery.CountAsync();

            return new TrailQueryServiceModel()
            {
                TotalTrails = totalTrails,
                Trails = trails
            };
        }

        public async Task<IEnumerable<TrailOverviewServiceModel>> LastThreeTrailsAsync()
        {
            return await data.Trails
                .OrderByDescending(t => t.TrailId)
                .Take(3)
                .Select(t => new TrailOverviewServiceModel
                {
                    TrailId = t.TrailId,
                    Name = t.Name,
                    Distance = t.Distance,
                    DifficultyLevel = t.DifficultyLevel,
                    ImageUrl = t.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<TrailDetailsViewModel> TrailDetailsByIdAsync(int id)
        {
            return await data.Trails
                .Where(t => t.TrailId == id)
                .Select(t => new TrailDetailsViewModel()
                {
                    TrailId = t.TrailId,
                    Name = t.Name,
                    Description = t.Description,
                    ImageUrl = t.ImageUrl,
                    DifficultyLevel = t.DifficultyLevel,
                    Distance = t.Distance,
                    Duration = t.Duration,
                    ElevationGain = t.ElevationGain,
                    LastUpdated = t.LastUpdated,
                    Mountain = t.Mountain.Name,
                    Region = t.Region.Name
                })
                .FirstAsync();
        }

        public async Task<bool> TrailExistsAsync(int id)
        {
            return await data.Trails
                .AnyAsync(t => t.TrailId == id);
        }
    }
}
