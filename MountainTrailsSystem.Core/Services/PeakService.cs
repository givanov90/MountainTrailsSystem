using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Enumerations;
using MountainTrailsSystem.Core.Models.Peak;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Core.Services
{
    public class PeakService : IPeakService
    {
        private readonly MountainTrailsSystemDbContext data;

        public PeakService(MountainTrailsSystemDbContext _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<PeakServiceModel>> AllPeaksAsListAsync()
        {
                return await data.Peaks
                    .Select(p => new PeakServiceModel
                    {
                        PeakId = p.PeakId,
                        Name = p.Name
                    })
                    .ToListAsync();
        }

        public async Task<PeakQueryServiceModel> AllPeaksAsync(int currentPage = 1)
        {
            var peaksQuery = data.Peaks.AsQueryable();

            var peaks = await peaksQuery
                .Skip((currentPage - 1) * 3)
                .Take(3)
                .Select(p => new PeakOverviewServiceModel
                {
                    PeakId = p.PeakId,
                    Name = p.Name,
                    Elevation = p.Elevation,
                    ImageUrl = p.ImageUrl,
                    Mountain = p.Mountain.Name
                })
                .ToListAsync();

            int totalPeaks = await peaksQuery.CountAsync();

            return new PeakQueryServiceModel()
            {
                TotalPeaks = totalPeaks,
                Peaks = peaks
            };
        }

        public async Task<IEnumerable<TrailByPeakServiceModel>> AllTrailsByPeakIdAsync(int peakId, TrailSortCriteria? sortCriteria)
        {
            var trails = await data.TrailsPeaks
                .AsQueryable()
                .Where(tp => tp.PeakId == peakId)
                .Select(tp => new TrailByPeakServiceModel()
                {
                    TrailId = tp.TrailId,
                    Name = tp.Trail.Name,
                    DifficultyLevel = tp.Trail.DifficultyLevel,
                    Distance = tp.Trail.Distance,
                    Duration = tp.Trail.Duration,
                    ElevationGain = tp.Trail.ElevationGain
                })
                .OrderBy(t => t.DifficultyLevel)
                .ToListAsync();

            switch (sortCriteria)
            {
                case TrailSortCriteria.DifficultyLevelAscending:
                    return trails.OrderBy(t => t.DifficultyLevel);
                case TrailSortCriteria.DifficultyLevelDescending:
                    return trails.OrderByDescending(t => t.DifficultyLevel);
                case TrailSortCriteria.DurationAscending:
                    return trails.OrderBy(t => t.Duration);
                case TrailSortCriteria.DurationDescending:
                    return trails.OrderByDescending(t => t.Duration);
                case TrailSortCriteria.DistanceAscending:
                    return trails.OrderBy(t => t.Distance);
                case TrailSortCriteria.DistanceDescending:
                    return trails.OrderByDescending(t => t.Distance);
                case TrailSortCriteria.ElevationGainAscending:
                    return trails.OrderBy(t => t.ElevationGain);
                case TrailSortCriteria.ElevationGainDescending:
                    return trails.OrderByDescending(t => t.ElevationGain);
                default:
                    return trails.OrderBy(t => t.DifficultyLevel);
            }
        }

        public async Task CreatePeakAsync(CreatePeakFormModel model)
        {
            var peak = new Peak()
            {
                Name = model.Name,
                Description = model.Description,
                Elevation = model.Elevation,
                ImageUrl = model.ImageUrl,
                MountainId = model.MountainId
            };

            await data.Peaks.AddAsync(peak);
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<PeakOverviewServiceModel>> FindPeaksByConditionAsync(string condition)
        {
            var peaks = new List<PeakOverviewServiceModel>();

            if (condition != null)
            {
                string normalizedCondition = condition.ToLower();

                return await data.Peaks
                    .Where(p => p.Name.ToLower().Contains(normalizedCondition))
                    .Select(p => new PeakOverviewServiceModel
                    {
                        PeakId = p.PeakId,
                        Name = p.Name,
                        Elevation = p.Elevation,
                        ImageUrl = p.ImageUrl,
                        Mountain = p.Mountain.Name
                    })
                    .ToListAsync();
            }

            return peaks;
        }

        public async Task<PeakDetailsViewModel> PeakDetailsByIdAsync(int peakId)
        {
            return await data.Peaks
                .Where(p => p.PeakId == peakId)
                .Select(p => new PeakDetailsViewModel()
                {
                     PeakId = peakId,
                     Name = p.Name,
                     Description = p.Description,
                     Elevation = p.Elevation,
                     ImageUrl  = p.ImageUrl,
                     Mountain = p.Mountain.Name
                })
                .FirstAsync();
        }

        public async Task<bool> PeakExistsAsync(int peakId)
        {
            return await data.Peaks
                .AnyAsync(p => p.PeakId == peakId);
        }
    }
}
