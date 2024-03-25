using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Region entity")]
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        [MaxLength(RegionNameMaximumLength)]
        public string Name { get; set; } = String.Empty;

        public ICollection<Mountain> Mountains { get; set; } = new List<Mountain>();
    }
}