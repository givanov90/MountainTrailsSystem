using MountainTrailsSystem.Core.Models.Mountain;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;
using static MountainTrailsSystem.Infrastructure.Constants.MessageConstants;

namespace MountainTrailsSystem.Core.Models.Region
{
    public class CreateRegionFormModel
    {
        [Required]
        [StringLength(RegionNameMaximumLength,
            MinimumLength = RegionNameMinimumLength,
            ErrorMessage = FieldLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Mountains")]
        public int MountainId { get; set; }
        public IEnumerable<MountainServiceModel> Mountains { get; set; } =
                new List<MountainServiceModel>();
    }
}
