﻿namespace MountainTrailsSystem.Core.Models
{
    public class AllTrailsQueryModel
    {
        public int CurrentPage { get; init; } = 1;

        public int TotalTrails { get; set; }

        public IEnumerable<TrailOverviewServiceModel> Trails { get; set; } = new List<TrailOverviewServiceModel>();
    }
}
