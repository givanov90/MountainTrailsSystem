using Microsoft.AspNetCore.Identity;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserTrail> SavedVisitedTrails { get; set; } = new List<UserTrail>();
    }
}
