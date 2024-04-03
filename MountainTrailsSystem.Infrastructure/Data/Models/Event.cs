using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("Event entity")]
    public class Event
    {
        [Key]
        [Comment("Event identifier")]
        public int EventId { get; set; }

        [Required]
        [MaxLength(EventTitleMaximumLength)]
        [Comment("Event title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescriptionMaximumLength)]
        [Comment("Event description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Date and time when the event starts")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("Date and time when the event ends")]
        public DateTime End { get; set; }
    }
}
