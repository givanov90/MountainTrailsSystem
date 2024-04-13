using System.ComponentModel.DataAnnotations;

namespace MountainTrailsSystem.Core.Models
{
    public class AllTrailsQueryModel
    {
        public int CurrentPage { get; init; } = 1;

        public int TotalTrails { get; set; }

        [Display(Name = "Search by keyword")]
        public string term { get; init; } = null!;

        public IEnumerable<TrailOverviewServiceModel> Trails { get; set; } = new List<TrailOverviewServiceModel>();
    }
}
