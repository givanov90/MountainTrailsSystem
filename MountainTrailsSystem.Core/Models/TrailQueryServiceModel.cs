namespace MountainTrailsSystem.Core.Models
{
    public class TrailQueryServiceModel
    {
        public int TotalTrails { get; set; }

        public IEnumerable<TrailOverviewServiceModel> Trails { get; set; } = new List<TrailOverviewServiceModel>();
    }
}
