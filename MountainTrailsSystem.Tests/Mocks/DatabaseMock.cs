using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Infrastructure.Data;

namespace MountainTrailsSystem.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static MountainTrailsSystemDbContext Instance
        {
            get 
            { 
                var options = new DbContextOptionsBuilder<MountainTrailsSystemDbContext>()
                    .UseInMemoryDatabase("MountainTrailsSystemInMemoryDb"
                        + DateTime.Now.Ticks.ToString())
                    .Options;

                return new MountainTrailsSystemDbContext(options, false); ;
            }
        }
    }
}
