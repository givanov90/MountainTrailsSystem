namespace MountainTrailsSystem.Core.Models
{
    public class PeakQueryServiceModel
    {
        public int TotalPeaks { get; set; }

        public IEnumerable<PeakOverviewServiceModel> Peaks { get; set; } = new List<PeakOverviewServiceModel>();
    }
}
