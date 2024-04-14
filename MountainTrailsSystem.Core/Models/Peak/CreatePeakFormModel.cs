using MountainTrailsSystem.Core.Models.Mountain;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models.Peak
{
    public class CreatePeakFormModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PeakNameMaximumLength,
            MinimumLength = PeakNameMinimumLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PeakDescriptionMaximumLength,
            MinimumLength = PeakDescriptionMinimumLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(PeakMinimumElevation, PeakMaximumElevation, ErrorMessage = PeakElevationErrorMessage)]
        public int Elevation { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Mountain")]
        public int MountainId { get; set; }

        public IEnumerable<MountainServiceModel> Mountains { get; set; } =
            new List<MountainServiceModel>();
    }
}
