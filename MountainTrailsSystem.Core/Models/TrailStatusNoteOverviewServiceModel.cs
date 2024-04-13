namespace MountainTrailsSystem.Core.Models
{
    public class TrailStatusNoteOverviewServiceModel
    {
        public int TrailStatusNoteId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Trail { get; set; } = string.Empty;
    }
}
