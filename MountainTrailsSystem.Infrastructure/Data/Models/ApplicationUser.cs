using Microsoft.AspNetCore.Identity;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserTrail> SavedTrails { get; set; } = new List<UserTrail>();

        public ICollection<UserTrail> VisitedTrails { get; set; } = new List<UserTrail>();

        public ICollection<Event> EventsToAttend { get; set; } = new List<Event>();
    }
}
