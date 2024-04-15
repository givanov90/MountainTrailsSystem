using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Enumerations;
using MountainTrailsSystem.Core.Models.Peak;
using MountainTrailsSystem.Core.Services;

namespace MountainTrailsSystem.Tests.Tests
{
    [TestFixture]
    public class PeakServiceTests : UnitTestsBase
    {
        private IPeakService peakService;

        [OneTimeSetUp]
        public void SetUp()
            => peakService = new PeakService(data);


        [Test]
        public async Task AllPeaksAsListAsync_ShouldReturnCorrectCount()
        {
            var peaks = await peakService.AllPeaksAsListAsync();

            int expectedCount = data.Peaks.Count();

            Assert.That(peaks.Count().Equals(expectedCount));
        }

        [Test]
        public async Task AllPeaksAsListAsync_ShouldReturnCorrectValues()
        {
            var peaks = await peakService.AllPeaksAsListAsync();

            var firstPeak = peaks.First();

            int expectedId = data.Peaks.First().PeakId;
            string expectedName = data.Peaks.First().Name;

            Assert.That(firstPeak.PeakId.Equals(expectedId));
            Assert.That(firstPeak.Name.Equals(expectedName));
        }

        [Test]
        public async Task AllPeaksAsync_ShouldReturnCorrectCount()
        {
            var peaks = await peakService.AllPeaksAsync(1);

            int expectedCount = data.Peaks.Count();

            Assert.That(peaks.TotalPeaks.Equals(expectedCount));
            Assert.That(peaks.Peaks.Count().Equals(3));
        }

        [Test]
        public async Task AllPeaksAsync_ShouldReturnCorrectValues()
        {
            var peaks = await peakService.AllPeaksAsync(1);

            var firstPeak = peaks.Peaks.First();

            int expectedId = data.Peaks.First().PeakId;
            string expectedName = data.Peaks.First().Name;

            Assert.That(firstPeak.PeakId.Equals(expectedId));
            Assert.That(firstPeak.Name.Equals(expectedName));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldReturnCorrectCollectionOfTrails()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, null);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .ToList();


            var firstTrail = trails.First();

            var expectedFirstTrail = expectedTrails
                .Where(tp => tp.TrailId == firstTrail.TrailId)
                .Select(tp => tp.Trail)
                .First();

            Assert.That(trails.Count, Is.EqualTo(expectedTrails.Count));
            Assert.That(firstTrail.Name.Equals(expectedFirstTrail.Name));
            Assert.That(firstTrail.Distance.Equals(expectedFirstTrail.Distance));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_DifficultyLevelAscending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.DifficultyLevelAscending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderBy(t => t.DifficultyLevel);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_DifficultyLevelDescending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.DifficultyLevelDescending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderByDescending(t => t.DifficultyLevel);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_DurationAscending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.DurationAscending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderBy(t => t.Duration);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_DurationDescending()
        {
            var lastPeak = data.Peaks.Last();

            var trails = await peakService.AllTrailsByPeakIdAsync(lastPeak.PeakId, TrailSortCriteria.DurationDescending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == lastPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderByDescending(t => t.Duration);

            Assert.That(trails.Last().Name.Equals(expectedTrails.Last().Name));
            Assert.That(trails.Last().Distance.Equals(expectedTrails.Last().Distance));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_DistanceAscending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.DistanceAscending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderBy(t => t.Distance);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_DistanceDescending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.DistanceDescending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderByDescending(t => t.Distance);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_ElevationGainAscending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.ElevationGainAscending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderBy(t => t.ElevationGain);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task AllTrailsByPeakIdAsync_ShouldSortTrailsCorrectly_ElevationGainDescending()
        {
            var firstPeak = data.Peaks.First();

            var trails = await peakService.AllTrailsByPeakIdAsync(firstPeak.PeakId, TrailSortCriteria.ElevationGainDescending);

            var expectedTrails = data.TrailsPeaks
                .Where(tp => tp.PeakId == firstPeak.PeakId)
                .Select(tp => tp.Trail)
                .OrderByDescending(t => t.ElevationGain);

            Assert.That(trails.First().Name.Equals(expectedTrails.First().Name));
            Assert.That(trails.First().Duration.Equals(expectedTrails.First().Duration));
        }

        [Test]
        public async Task CreatePeakAsync_ShouldCreatePeakCorrectly()
        {
            var model = new CreatePeakFormModel()
            {
                Name = "Musala",
                Description = "Musala Peak, towering at 2,925 meters, is the highest summit in Bulgaria and the entire Balkan Peninsula. Located in the Rila Mountains, it offers breathtaking views and is a popular destination for hikers and nature enthusiasts.",
                Elevation = 2925,
                ImageUrl = "https://www.infopointbg.com/media/7/2448.jpg",
                MountainId = 1
            };

            await peakService.CreatePeakAsync(model);

            var newPeak = data.Peaks.Last();

            Assert.That(model.Name.Equals(newPeak.Name));
            Assert.That(model.Elevation.Equals(newPeak.Elevation));
        }

        [Test]
        public async Task FindPeaksByConditionAsync_ShouldReturnOnePeakWhenConditionIsCorrect()
        {
            string condition = "malyovitsa";

            var peaks = await peakService.FindPeaksByConditionAsync(condition);

            var expectedPeaks = data.Peaks
                .Where(p => p.Name.ToLower().Contains(condition));

            int expectedCount = expectedPeaks.Count();
            string expectedName = expectedPeaks.First().Name;
            int expectedElevation = expectedPeaks.First().Elevation;

            Assert.That(peaks.Count().Equals(expectedCount));
            Assert.That(peaks.First().Name.Equals(expectedName));
            Assert.That(peaks.First().Elevation.Equals(expectedElevation));
        }

        [Test]
        public async Task FindPeaksByConditionAsync_ShouldReturnEmptyCollectionWhenConditionIsNotCorrect()
        {
            string condition = "Matterhorn";

            var peaks = await peakService.FindPeaksByConditionAsync(condition);

            int expectedCount = 0;

            Assert.That(peaks.Count().Equals(expectedCount));
        }

        [Test]
        public async Task FindPeaksByConditionAsync_ShouldReturnEmptyCollectionWhenConditionIsNull()
        {
            var peaks = await peakService.FindPeaksByConditionAsync(null);

            int expectedCount = 0;

            Assert.That(peaks.Count().Equals(expectedCount));
        }

        [Test]
        public async Task PeakDetailsByIdAsync_ShouldReturnCorrectDetails()
        {
            int peakId = 1;

            var peak = await peakService.PeakDetailsByIdAsync(peakId);

            var expectedPeak = data.Peaks
                .Where(p => p.PeakId == peakId)
                .First();

            Assert.That(peak.Name == expectedPeak.Name);
            Assert.That(peak.Description == expectedPeak.Description);
        }

        [Test]
        public async Task PeakExistsAsync_ShouldReturnTrueWithCorrectPeakId()
        {
            int peakId = 2;

            bool peakExists = await peakService.PeakExistsAsync(peakId);

            Assert.IsTrue(peakExists);
        }

        [Test]
        public async Task PeakExistsAsync_ShouldReturnFalseWithIncorrectPeakId()
        {
            int peakId = 222222222;

            bool peakExists = await peakService.PeakExistsAsync(peakId);

            Assert.IsFalse(peakExists);
        }

        [OneTimeTearDown]
        public void TearDownBase()
    => data.Dispose();
    }
}
