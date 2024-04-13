using MountainTrailsSystem.Infrastructure.Attributes;
using MountainTrailsSystem.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models
{
    public class CreateTrailFormModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TrailNameMaximumLength, MinimumLength = TrailNameMinimumLength, ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TrailDescriptionMaximumLength, MinimumLength = TrailDescriptionMinimumLength, ErrorMessage = FieldLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(TrailMinimumElevationGain, TrailMaximumElevationGain, ErrorMessage = TrailElevationErrorMessage)]
        [Display(Name = "Elevation gain")]
        public int ElevationGain { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(TrailMinimumDistance, TrailMaximumDistance, ErrorMessage = TrailDurationErrorMessage)]
        public double Distance { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(TrailDurationMinimumHours, TrailDurationMaximumHours, ErrorMessage = DurationHoursErrorMessage)]
        public int DurationHours { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(TrailDurationMinimumMinutes, TrailDurationMaximumMinutes, ErrorMessage = DurationMinutesErrorMessage)]
        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Difficulty level")]
        public DifficultyLevel? DifficultyLevel { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime LastUpdated { get; set; }

        [Range(TrailRatingMinimumValue, TrailRatingMaximumValue)]
        public int Rating { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Mountain")]
        public int MountainId { get; set; }

        public IEnumerable<MountainServiceModel> Mountains { get; set; } =
            new List<MountainServiceModel>();

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Region")]
        public int RegionId { get; set; }

        public IEnumerable<RegionServiceModel> Regions { get; set; } =
            new List<RegionServiceModel>();

        [Display(Name = "Peak(s)")]
        public int PeakId { get; set; }

        public IEnumerable<PeakServiceModel> Peaks { get; set; } = new List<PeakServiceModel>();

        [Display(Name = "Selected peak(s)")]
        public List<int> SelectedPeaksIds { get; set; } = new List<int>();
    }
}
