using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Connection between trail and peak entities")]
    public class TrailPeak
    {
        [Required]
        [Comment("Trail identifier")]
        public int TrailId { get; set; }

        [ForeignKey(nameof(TrailId))]
        public Trail Trail { get; set; } = null!;

        [Comment("Peak identifier")]
        public int? PeakId { get; set; }

        [ForeignKey(nameof(PeakId))]
        public Peak? Peak { get; set; }
    }
}