using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.Trail;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Infrastructure.Enumerations;

namespace MountainTrailsSystem.Core.Services
{
    public class TrailService : ITrailService
    {
        private readonly MountainTrailsSystemDbContext data;

        public TrailService(MountainTrailsSystemDbContext _data)
        {
            data = _data;
        } 

        public async Task<IEnumerable<TrailOverviewServiceModel>> AllTrailsByUserIdAsync(string userId)
        {
            return await data.UsersTrails
                .Where(ut => ut.UserId == userId)
                .Select(ut => new TrailOverviewServiceModel()
                {
                    TrailId = ut.Trail.TrailId,
                    Name = ut.Trail.Name,
                    ImageUrl = ut.Trail.ImageUrl,
                    Distance = ut.Trail.Distance,
                    DifficultyLevel = ut.Trail.DifficultyLevel
                })
                .ToListAsync();
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

        public async Task<TrailDetailsViewModel> TrailDetailsByIdAsync(int trailId)
        {
            return await data.Trails
                .Where(t => t.TrailId == trailId)
                .Select(t => new TrailDetailsViewModel()
                {
                    TrailId = trailId,
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


        public async Task UpdateAsync(int trailId, TrailUpdateFormModel model)
        {
            var trail = await data.Trails
                .Where(t => t.TrailId == trailId)
                .FirstOrDefaultAsync();

            if (trail != null)
            {
                trail.Duration = model.Duration;
                trail.Description = model.Description;
                trail.ElevationGain = model.ElevationGain;
                trail.DifficultyLevel = model.DifficultyLevel;
                trail.Distance = model.Distance;
                trail.Name = model.Name;
                trail.LastUpdated = DateTime.UtcNow;
            }

            await data.SaveChangesAsync();
        }

        public async Task<TrailUpdateFormModel?> GetTrailUpdateFormModelAsync(int trailId)
        {
            return await data.Trails
                .Where(t => t.TrailId == trailId)
                .Select(t => new TrailUpdateFormModel
                {
                    Name = t.Name,
                    Description = t.Description,
                    ImageUrl = t.ImageUrl,
                    DifficultyLevel = t.DifficultyLevel,
                    Distance = t.Distance,
                    Duration = t.Duration,
                    ElevationGain = t.ElevationGain,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsTrailSavedByUserAsync(string userId, int trailId)
        {
            var user = await data.Users.FindAsync(userId);

            var userTrail = await data.UsersTrails
                .Where(t => t.TrailId == trailId && t.UserId == userId)
                .FirstOrDefaultAsync();

            if (user != null && userTrail != null)
            {
                return userTrail.IsSaved;
            }

            return false;
        }

        public async Task<bool> IsTrailVisitedByUserAsync(string userId, int trailId)
        {
            var user = await data.Users.FindAsync(userId);

            var userTrail = await data.UsersTrails
                .Where(t => t.TrailId == trailId && t.UserId == userId)
                .FirstOrDefaultAsync();

            if (user != null && userTrail != null)
            {
                return userTrail.IsVisited;
            }

            return false;
        }

        public async Task RemoveTrailFromSavedAsync(string userId, int trailId)
        {
            var user = await data.Users.FindAsync(userId);

            if (user != null && await IsTrailSavedByUserAsync(userId, trailId))
            {
                var userTrail = await data.UsersTrails
                    .Where(ut => ut.UserId == userId && ut.TrailId == trailId)
                    .FirstAsync();

                if (!await IsTrailVisitedByUserAsync(userId, trailId))
                {
                    user.SavedVisitedTrails.Remove(userTrail);
                }
                else
                {
                    userTrail.IsSaved = false;
                }

                await data.SaveChangesAsync();
            }
        }

        public async Task AddTrailToSavedAsync(string userId, int trailId)
        {
            var user = await data.Users.FindAsync(userId);
            var userTrail = await data.UsersTrails.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TrailId == trailId);

            if (user != null && !await IsTrailSavedByUserAsync(userId, trailId))
            {
                if (userTrail == null)
                {
                    userTrail = new UserTrail
                    {
                        UserId = userId,
                        TrailId = trailId,
                        IsSaved = true,
                        IsVisited = false
                    };

                    user.SavedVisitedTrails.Add(userTrail);
                }
                else
                {
                    userTrail.IsSaved = true;
                }

                await data.SaveChangesAsync();
            }
        }

        public async Task AddTrailToVisitedAsync(string userId, int trailId)
        {
            var user = await data.Users.FindAsync(userId);
            var userTrail = await data.UsersTrails.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TrailId == trailId);

            if (user != null && !await IsTrailVisitedByUserAsync(userId, trailId))
            {
                if (userTrail == null)
                {
                    userTrail = new UserTrail
                    {
                        UserId = userId,
                        TrailId = trailId,
                        IsVisited = true,
                        IsSaved = false
                    };

                    user.SavedVisitedTrails.Add(userTrail);
                }
                else
                {
                    userTrail.IsVisited = true;
                }  
            }

            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrailOverviewServiceModel>> AllSavedTrailsByUserIdAsync(string userId)
        {
                return await data.UsersTrails
                    .Where(ut => ut.UserId == userId && ut.IsSaved == true)
                    .Select(ut => new TrailOverviewServiceModel()
                    {
                        TrailId = ut.Trail.TrailId,
                        Name = ut.Trail.Name,
                        ImageUrl = ut.Trail.ImageUrl,
                        Distance = ut.Trail.Distance,
                        DifficultyLevel = ut.Trail.DifficultyLevel
                    })
                    .ToListAsync();
        }

        public async Task<IEnumerable<TrailOverviewServiceModel>> AllVisitedTrailsByUserIdAsync(string userId)
        {
            return await data.UsersTrails
                .Where(ut => ut.UserId == userId && ut.IsVisited == true)
                .Select(ut => new TrailOverviewServiceModel()
                {
                    TrailId = ut.Trail.TrailId,
                    Name = ut.Trail.Name,
                    ImageUrl = ut.Trail.ImageUrl,
                    Distance = ut.Trail.Distance,
                    DifficultyLevel = ut.Trail.DifficultyLevel
                })
                .ToListAsync();
        }

        public async Task CreateTrailAsync(CreateTrailFormModel model)
        {
            if (model.DifficultyLevel != null)
            {
                var trail = new Trail()
                {
                    Name = model.Name,
                    Description = model.Description,
                    DifficultyLevel = model.DifficultyLevel.Value,
                    Distance = model.Distance,
                    Duration = new TimeSpan(model.DurationHours,model.DurationMinutes,0),
                    ElevationGain = model.ElevationGain,
                    ImageUrl = model.ImageUrl,
                    LastUpdated = DateTime.UtcNow,
                    MountainId = model.MountainId,
                    RegionId = model.RegionId
                };

                await data.Trails.AddAsync(trail);
                await data.SaveChangesAsync();

                foreach (var peakId in model.SelectedPeaksIds)
                {
                    var trailPeak = new TrailPeak()
                    {
                        TrailId = trail.TrailId,
                        PeakId = peakId
                    };

                    await data.TrailsPeaks.AddAsync(trailPeak);
                }

                await data.SaveChangesAsync();
            }
        }

        public async Task<bool> TrailByNameExistsAsync(string trailName)
        {
            return await data.Trails
                .AnyAsync(t => t.Name == trailName);
        }

        public async Task<IEnumerable<TrailServiceModel>> AllTrailsAsListAsync()
        {
            return await data.Trails
                .Select(t => new TrailServiceModel
                {
                    TrailId = t.TrailId,
                    Name = t.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TrailOverviewServiceModel>> FindTrailsByConditionsAsync(int? regionId, DifficultyLevel? difficultyLevel, double? duration, int? elevationGain)
        {
            var trailsQuery = data.Trails.AsQueryable();

            if (regionId !=null)
            {
                trailsQuery = trailsQuery.
                    Where(t => t.RegionId == regionId);
            }

            if (difficultyLevel != null)
            {
                trailsQuery = trailsQuery.
                    Where(t => t.DifficultyLevel == difficultyLevel);
            }

            if (duration != null)
            {
                int hours = (int)duration;
                int minutes = (int)((duration - hours) * 60);

                TimeSpan searchedDuration = new TimeSpan(hours, minutes, 0);

                trailsQuery = trailsQuery.
                    Where(t => t.Duration <= searchedDuration);
            }

            if (elevationGain != null)
            {
                trailsQuery = trailsQuery.
                    Where(t => t.ElevationGain <= elevationGain);
            }

            return await trailsQuery
                .Select(t => new TrailOverviewServiceModel
                {
                    TrailId = t.TrailId,
                    Name = t.Name,
                    DifficultyLevel = t.DifficultyLevel,
                    Distance = t.Distance,
                    ImageUrl = t.ImageUrl
                })
                .ToListAsync();
        }
    }
}
