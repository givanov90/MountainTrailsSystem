using MountainTrailsSystem.Core.Contracts;

namespace MountainTrailsSystem.Core.Models
{
    public class TrailServiceModel : ITrailModel
    {
        public int TrailId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
