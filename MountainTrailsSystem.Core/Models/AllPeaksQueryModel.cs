namespace MountainTrailsSystem.Core.Models
{
    public class AllPeaksQueryModel
    {
        public int CurrentPage { get; init; } = 1;

        public int TotalPeaks { get; set; }

        public IEnumerable<PeakOverviewServiceModel> Peaks { get; set; } = new List<PeakOverviewServiceModel>();
    }
}
