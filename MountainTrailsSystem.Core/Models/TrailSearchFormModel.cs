using MountainTrailsSystem.Infrastructure.Attributes;
using MountainTrailsSystem.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;


namespace MountainTrailsSystem.Core.Models
{
    public class TrailSearchFormModel
    {
        [Display(Name = "Region")]
        public int? RegionId { get; set; }

        public IEnumerable<RegionServiceModel> Regions { get; set; } =
            new List<RegionServiceModel>();

        [Display(Name = "Difficulty level")]
        public DifficultyLevel? DifficultyLevel { get; set; }

        [Range(TrailMinimumDurationAsDouble, TrailMaximumDurationAsDouble)]
        public double? Duration { get; set; }

        [Range(TrailMinimumElevationGain, TrailMaximumElevationGain)]
        public int? Elevation { get; set; }
    }
}
