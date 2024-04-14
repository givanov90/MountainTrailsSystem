namespace MountainTrailsSystem.Core.Models.Peak
{
    public class PeakQueryServiceModel
    {
        public int TotalPeaks { get; set; }

        public IEnumerable<PeakOverviewServiceModel> Peaks { get; set; } = new List<PeakOverviewServiceModel>();
    }
}
