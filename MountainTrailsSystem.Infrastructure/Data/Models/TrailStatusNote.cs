using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Request for update of the trail status")]
    public class TrailStatusNote
    {
        [Key]
        [Comment("TrailStatusNote identifier")]
        public int TrailStatusNoteId { get; set; }

        [Required]
        [MaxLength(TrailStatusNoteMaximumLength)]
        [Comment("Description of the updated trail status")]
        public string Description { get; set; } = string.Empty;

        [Comment("Image verifying the updated trail status")]
        public string ImageUrl { get; set; } = string.Empty;

        [Comment("Flag showing if the given note is resolved")]
        public bool IsResolved { get; set; } = false;

        [Required]
        [Comment("Trail identifier")]
        public int TrailId { get; set; }

        [ForeignKey(nameof(TrailId))]
        public Trail Trail { get; set; } = null!;
    }
}
