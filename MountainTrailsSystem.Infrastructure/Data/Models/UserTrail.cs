using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Connection between ApplicationUser and Trail entities")]
    public class UserTrail
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Trail identifier")]
        public int TrailId { get; set; }

        [ForeignKey(nameof(TrailId))]
        public Trail Trail { get; set; } = null!;

        [Comment("Is trail saved by user")]
        public bool IsSaved { get; set; }

        [Comment("Is trail visited by user")]
        public bool IsVisited { get; set; }
    }
}
