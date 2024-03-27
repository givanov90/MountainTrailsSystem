using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Infrastructure.Attributes;
using MountainTrailsSystem.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Mountain trail")]
    public class Trail
    {
        [Key]
        [Comment("Trail identifier")]
        public int TrailId { get; set; }

        [Required]
        [MaxLength(TrailNameMaximumLength)]
        [Comment("Trail name")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MaxLength(TrailDescriptionMaximumLength)]
        [Comment("Trail description")]
        public string Description { get; set; } = String.Empty;

        [Required]
        [Comment("Image URL of the trail")]
        public string ImageUrl { get; set; } = String.Empty;

        [Required]
        [Range(TrailMinimumElevationGain, int.MaxValue)]
        [Comment("Elevation gained on the trail")]
        public int ElevationGain { get; set; }

        [Required]
        [Range(TrailMinimumDistance, double.MaxValue)]
        [Comment("Distance of the trail")]
        public double Distance { get; set; }

        [Required]
        [DurationRange(TrailMinimumDuration, TrailMaximumDuration)]
        [Comment("Duration of the trail")]
        public TimeSpan Duration { get; set; }

        [Required]
        [Comment("Difficulty level of the trail")]
        public DifficultyLevel DifficultyLevel { get; set; }

        [Required]
        [Comment("Date and time of last update of the trail's actual state")]
        public DateTime LastUpdated { get; set; }

        [Range(TrailRatingMinimumValue, TrailRatingMaximumValue)]
        [Comment("Rating of the trail")]
        public int Rating { get; set; }

        [Required]
        [Comment("Mountain identifier")]
        public int MountainId { get; set; }

        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;

        [Required]
        [Comment("Region identifier")]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; } = null!;

        public ICollection<TrailPeak> Peaks { get; set; } = new List<TrailPeak>();
    }
}