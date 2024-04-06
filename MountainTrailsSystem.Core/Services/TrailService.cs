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

        public async Task<TrailQueryServiceModel> AllTrailsAsync(int currentPage = 1, int trailsPerPage = 1)
        {
            var trailsQuery = data.Trails.AsQueryable();

            var trails = await trailsQuery
                .Skip((currentPage - 1) * trailsPerPage)
                .Take(trailsPerPage)
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
    }
}
