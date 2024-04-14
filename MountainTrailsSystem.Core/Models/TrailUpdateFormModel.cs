using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Infrastructure.Attributes;
using MountainTrailsSystem.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models
{
    public class TrailUpdateFormModel : ITrailModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TrailNameMaximumLength,
            MinimumLength = TrailNameMinimumLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TrailDescriptionMaximumLength,
            MinimumLength = TrailDescriptionMinimumLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(TrailMinimumElevationGain, int.MaxValue)]
        [Display(Name = "Elevation Gain")]
        public int ElevationGain { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(TrailMinimumDistance, double.MaxValue)]
        public double Distance { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DurationRange(TrailMinimumDuration, TrailMaximumDuration)]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DifficultyLevel DifficultyLevel { get; set; }
    }
}
