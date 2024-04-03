using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Mountain entity")]
    public class Mountain
    {
        [Key]
        [Comment("Mountain identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MountainNameMaximumLength)]
        [Comment("Mountain name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<MountainRegion> Regions { get; set; } = new List<MountainRegion>();

        public ICollection<Trail> Trails { get; set; } = new List<Trail>();

        public ICollection<Peak> Peaks { get; set; } = new List<Peak>();
    }
}