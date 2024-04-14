using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Enumerations;
using MountainTrailsSystem.Infrastructure.Enumerations;

namespace MountainTrailsSystem.Core.Models.Peak
{
    public class TrailByPeakServiceModel : ITrailModel
    {
        public int TrailId { get; set; }
        public string Name { get; set; } = string.Empty;

        public DifficultyLevel DifficultyLevel { get; set; }

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }

        public int ElevationGain { get; set; }

        public TrailSortCriteria SortCriteria { get; set; }
    }
}
