using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models
{
    public class PeakSearchConditionFormModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PeakSearchConditionMaximumLength, MinimumLength = PeakSearchConditionMinimumLength, ErrorMessage = FieldLengthErrorMessage)]
        public string Condition { get; set; } = string.Empty;
    }
}
