using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Mountain peak")]
    public class Peak
    {
        [Key]
        [Comment("Peak identifier")]
        public int PeakId { get; set; }

        [Required]
        [MaxLength(PeakNameMaximumLength)]
        [Comment("Peak name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(PeakDescriptionMaximumLength)]
        [Comment("Peak description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(PeakMinimumElevation, PeakMaximumElevation)]
        [Comment("Peak elevation")]
        public int Elevation { get; set; }
        
        [Required]
        [Comment("Image URL of the peak")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Mountain identifier")]
        public int MountainId { get; set; }

        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;

        public ICollection<TrailPeak> Trails { get; set; } = new List<TrailPeak>();
    }
}