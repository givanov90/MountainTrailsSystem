using MountainTrailsSystem.Infrastructure.Enumerations;

namespace MountainTrailsSystem.Core.Models
{
    public class TrailOverviewServiceModel
    {
        public int TrailId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public double Distance { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }
    }
}
