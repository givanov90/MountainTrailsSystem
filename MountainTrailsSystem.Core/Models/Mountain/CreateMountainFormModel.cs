using MountainTrailsSystem.Core.Models.Region;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models.Mountain
{
    public class CreateMountainFormModel
    {
        [Required]
        [StringLength(MountainNameMaximumLength,
            MinimumLength = MountainNameMinimumLength, ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Regions")]
        public int RegionId { get; set; }

        public IEnumerable<RegionServiceModel> Regions { get; set; } =
            new List<RegionServiceModel>();

        [Display(Name = "Selected Regions")]
        public List<int> SelectedRegionIds { get; set; } = new List<int>();
    }
}
