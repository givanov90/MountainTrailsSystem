using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Connection between mountain and region entities")]
    public class MountainRegion
    {
        [Required]
        [Comment("Region identifier")]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; } = null!;

        [Comment("Mountain identifier")]
        public int? MountainId { get; set; }

        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;
    }
}
