using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Infrastructure.Enumerations;

namespace MountainTrailsSystem.Core.Models
{
    public class TrailDetailsViewModel : ITrailModel
    {
        public int TrailId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int ElevationGain { get; set; }

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Mountain { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;
    }
}
