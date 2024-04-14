using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.Region;
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
        public async Task AllRegionsAsync_ShouldReturnCorrectCount()
        {
            var regions = await regionService.AllRegionsAsync();

            int expectedCount = data.Regions.Count();

            Assert.That(regions.Count().Equals(expectedCount));
        }

        [Test]
        public async Task RegionExistsAsync_ShouldReturnTrue_WithCorrectData()
        {
            string regionName = "Blagoevgrad";

            bool exists = await regionService.RegionExistsAsync(regionName);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task RegionExistsAsync_ShouldReturnFalse_WithIncorrectData()
        {
            string regionName = "London";

            bool exists = await regionService.RegionExistsAsync(regionName);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task CreateRegionAsync_ShouldCreateRegionCorrectly()
        {
            var model = new CreateRegionFormModel()
            {
                Name = "Varna",
                MountainId = 1
            };

            var region = regionService.CreateRegionAsync(model);

            bool newRegionExists = await regionService.RegionExistsAsync(model.Name);
            var regions = await regionService.AllRegionsAsync();

            Assert.IsTrue(newRegionExists);
            Assert.IsTrue(regions.Any(r => r.Name == model.Name));
        }

        [OneTimeTearDown]
        public void TearDownBase()
            => data.Dispose();
    }
}
