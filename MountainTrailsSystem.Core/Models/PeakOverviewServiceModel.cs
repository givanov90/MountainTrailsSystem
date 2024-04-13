﻿namespace MountainTrailsSystem.Core.Models
{
    public class PeakOverviewServiceModel
    {
        public int PeakId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int Elevation { get; set; }

        public string Mountain { get; set; } = string.Empty;
    }
}
