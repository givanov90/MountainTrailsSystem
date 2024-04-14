using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.Mountain;
using MountainTrailsSystem.Core.Services;

namespace MountainTrailsSystem.Tests.Tests
{
    [TestFixture]
    public class MountainServiceTests : UnitTestsBase
    {
        private IMountainService mountainService;

        [OneTimeSetUp]
        public void SetUp()
            => mountainService = new MountainService(data);


        [Test]
        public async Task AllMountainsAsync_ShouldReturnCorrectCount()
        {
            var mountains = await mountainService.AllMountainsAsync();

            int expectedCount = 4;

            Assert.That(mountains.Count().Equals(expectedCount));
        }

        [Test]
        public async Task MountainExistsAsync_ShouldReturnTrue_WithCorrectData()
        {
            string mountainName = "Pirin";

            bool exists = await mountainService.MountainExistsAsync(mountainName);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task MountainExistsAsync_ShouldReturnFalse_WithIncorrectData()
        {
            string mountainName = "Patagonia";

            bool exists = await mountainService.MountainExistsAsync(mountainName);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task CreateMountainAsync_ShouldCreateMountainCorrectly()
        {
            var model = new CreateMountainFormModel()
            {
                Name = "Stara planina",
                SelectedRegionIds = new List<int> { 1, 2, 4 }
            };

            var mountain = mountainService.CreateMountainAsync(model);

            bool newMountainExists = await mountainService.MountainExistsAsync(model.Name);
            var mountains = await mountainService.AllMountainsAsync();

            Assert.IsTrue(newMountainExists);
            Assert.IsTrue(mountains.Any(m => m.Name == model.Name));
        }


        [OneTimeTearDown]
        public void TearDownBase()
            => data.Dispose();
    }
}
