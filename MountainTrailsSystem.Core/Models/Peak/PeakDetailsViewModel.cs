using MountainTrailsSystem.Core.Contracts;

namespace MountainTrailsSystem.Core.Models.Peak
{
    public class PeakDetailsViewModel : IPeakModel
    {
        public int PeakId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Elevation { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public string Mountain { get; set; } = string.Empty;
    }
}
