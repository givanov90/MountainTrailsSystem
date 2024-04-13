namespace MountainTrailsSystem.Core.Models
{
    public class StatusNoteDetailsViewModel
    {
        public int TrailStatusNoteId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int TrailId { get; set; }

        public string Trail { get; set; } = string.Empty;
    }
}
