using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Services;

namespace MountainTrailsSystem.Tests.Tests
{
    [TestFixture]
    public class RegionServiceTests : UnitTestsBase
    {
        private IRegionService regionService;

        [OneTimeSetUp]
        public void SetUp()
            => regionService = new RegionService(data);

        [Test]
        public async Task RegionExistsAsync_ShouldReturnTrue()
        {
            string regionName = "Blagoevgrad";

            bool exists = await regionService.RegionExistsAsync(regionName);

            Assert.IsTrue(exists);
        }

        [OneTimeTearDown]

        public void TearDownBase()
            => data.Dispose();
    }
}
