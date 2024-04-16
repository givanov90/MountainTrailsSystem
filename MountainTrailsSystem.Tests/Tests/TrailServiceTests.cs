using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.Trail;
using MountainTrailsSystem.Core.Services;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Infrastructure.Enumerations;

namespace MountainTrailsSystem.Tests.Tests
{
    [TestFixture]
    public class TrailServiceTests : UnitTestsBase
    {
        private ITrailService trailService;

        [OneTimeSetUp]
        public void SetUp()
            => trailService = new TrailService(data);

        [Test]
        public async Task LastThreeTrailsAsync_ShouldReturnCorrectResult()
        {
            var expectedTrails = data.Trails
                .OrderByDescending(t => t.TrailId)
                .Take(3);

            var expectedFirstTrail = expectedTrails.First();

            var trails = await trailService.LastThreeTrailsAsync();

            var firstTrail = trails.First();

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
            Assert.That(expectedFirstTrail.TrailId.Equals(firstTrail.TrailId));
            Assert.That(expectedFirstTrail.Distance.Equals(firstTrail.Distance));
        }

        [Test]
        public async Task TrailDetailsByIdAsync_ShouldReturnCorrectTrailDetails()
        {
            int trailId = 1;

            var trail = await trailService.TrailDetailsByIdAsync(trailId);

            var expectedTrail = data.Trails
                .Where(t => t.TrailId == trailId)
                .First();

            Assert.That(expectedTrail.Description.Equals(trail.Description));
            Assert.That(expectedTrail.ImageUrl.Equals(trail.ImageUrl));
        }

        [Test]
        public async Task TrailExistsAsync_ShouldReturnTrueWithCorrectTrailId()
        {
            int trailId = data.Trails.First().TrailId;

            bool exists = await trailService.TrailExistsAsync(trailId);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task TrailExistsAsync_ShouldReturnFalseWithIncorrectTrailId()
        {
            int trailId = 999999999;

            bool exists = await trailService.TrailExistsAsync(trailId);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateTrailCorrectly()
        {
            var model = new TrailUpdateFormModel()
            {
                Name = "Updated name",
                Description = "UpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdatedUpdated",
                DifficultyLevel = DifficultyLevel.Easy,
                Distance = 13.5,
                Duration = new TimeSpan(3, 30, 0),
                ElevationGain = 333,
                ImageUrl = "https://updatedimage.jpg"
            };

            var trail = data.Trails.First();

            await trailService.UpdateAsync(trail.TrailId, model);

            Assert.That(trail.Name.Equals(model.Name));
            Assert.That(trail.ElevationGain.Equals(model.ElevationGain));
        }

        [Test]
        public async Task GetTrailUpdateFormModelAsync_ShouldLoadCorrectData()
        {
            var trail = data.Trails.First();

            var model = await trailService.GetTrailUpdateFormModelAsync(trail.TrailId);

            Assert.That(trail.Name.Equals(model.Name));
            Assert.That(trail.Description.Equals(model.Description));
        }

        [Test]
        public async Task TrailByNameExistsAsync_ShouldReturnTrueWithCorrectTrail()
        {
            string trailName = data.Trails.First().Name;

            bool exists = await trailService.TrailByNameExistsAsync(trailName);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task TrailByNameExistsAsync_ShouldReturnFalseWithIncorrectTrail()
        {
            string trailName = "Zermatt - Matterhorn peak";

            bool exists = await trailService.TrailByNameExistsAsync(trailName);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task AllTrailsAsListAsync_ShouldReturnCorrectCollection()
        {
            var expectedTrails = data.Trails.ToList();

            var expectedFirstTrail = expectedTrails.First();

            var trails = await trailService.AllTrailsAsListAsync();

            var firstTrail = trails.First();

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
            Assert.That(expectedFirstTrail.Name.Equals(firstTrail.Name));
        }

        [Test]
        public async Task AllTrailsAsync_ShouldReturnCorrectCount()
        {
            var trails = await trailService.AllTrailsAsync(1);

            int expectedCount = data.Trails.Count();

            Assert.That(trails.TotalTrails.Equals(expectedCount));
            Assert.That(trails.Trails.Count().Equals(3));
        }

        [Test]
        public async Task AAllTrailsAsync_ShouldReturnCorrectValues()
        {
            var trails = await trailService.AllTrailsAsync(1);

            var firstTrail = trails.Trails.First();

            int expectedId = data.Trails.First().TrailId;
            string expectedName = data.Trails.First().Name;

            Assert.That(firstTrail.TrailId.Equals(expectedId));
            Assert.That(firstTrail.Name.Equals(expectedName));
        }

        [Test]
        public async Task CreateTrailAsync_ShouldCreateTrailCorrectly()
        {
            var model = new CreateTrailFormModel()
            {
                Name = "New trail",
                Description = "Newnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnewnew",
                Distance = 10.1,
                DurationHours = 5,
                DurationMinutes = 30,
                DifficultyLevel = DifficultyLevel.Extreme,
                ElevationGain = 2000,
                ImageUrl = "https://newtrailimage.jpg",
                MountainId = 1,
                SelectedPeaksIds = new List<int>() { 1, 2, 3 },
                RegionId = 1
            };

            await trailService.CreateTrailAsync(model);

            var newTrail = data.Trails.Last();

            Assert.That(model.Name.Equals(newTrail.Name));
            Assert.That(model.Description.Equals(newTrail.Description));
        }

        [Test]
        public async Task AddTrailToSavedAsync_ShouldSuccessfullyAddTrailToSaved()
        {
            var user = new ApplicationUser
            {
                Id = "test",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);

            bool isSaved = user.SavedVisitedTrails
                .Any(t => t.TrailId == trail.TrailId);

            bool exists = data.UsersTrails.Any(t => t.TrailId == trail.TrailId && t.UserId == user.Id && t.IsSaved == true);

            Assert.IsTrue(isSaved);
            Assert.That(user.SavedVisitedTrails.First().Trail.Name.Equals(trail.Name));
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task AddTrailToSavedAsync_ShouldDoNothingIfTrailAlreadyAdded()
        {
            var user = new ApplicationUser
            {
                Id = "test666",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);
            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);

            Assert.That(user.SavedVisitedTrails.Count().Equals(1));
        }

        [Test]
        public async Task AddTrailToSavedAsync_ShouldDoNothingIfUserDoesNotExist()
        {
            string userId = "NonExistingUserId";

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(userId, trail.TrailId);

            bool exists = data.UsersTrails.Any(ut => ut.UserId == userId && ut.TrailId == trail.TrailId);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task RemoveTrailFromSavedAsync_ShouldSuccessfullyRemoveTrailFromSaved()
        {
            var user = new ApplicationUser
            {
                Id = "test5",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);

            await trailService.RemoveTrailFromSavedAsync(user.Id, trail.TrailId);

            bool isRemoved = !user.SavedVisitedTrails
                .Any(t => t.TrailId == trail.TrailId && t.IsSaved == true);

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public async Task RemoveTrailFromSavedAsync_ShouldNotRemoveTrailFromUserCollectionIfTrailVisited()
        {
            var user = new ApplicationUser
            {
                Id = "test555",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);
            await trailService.AddTrailToVisitedAsync(user.Id, trail.TrailId);

            await trailService.RemoveTrailFromSavedAsync(user.Id, trail.TrailId);

            bool isNotRemoved = user.SavedVisitedTrails
                .Any(t => t.TrailId == trail.TrailId);

            Assert.IsTrue(isNotRemoved);
        }

        [Test]
        public async Task IsTrailSavedByUserAsync_ShouldReturnTrueIfTrailIsSaved()
        {
            var user = new ApplicationUser
            {
                Id = "test0",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);

            bool isSaved = await trailService.IsTrailSavedByUserAsync(user.Id, trail.TrailId);

            Assert.IsTrue(isSaved);
        }

        [Test]
        public async Task IsTrailSavedByUserAsync_ShouldReturnFalseIfTrailNotSaved()
        {
            var user = new ApplicationUser
            {
                Id = "test1",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            bool isSaved = await trailService.IsTrailSavedByUserAsync(user.Id, trail.TrailId);

            Assert.IsFalse(isSaved);
        }

        [Test]
        public async Task AddTrailToVisitedAsync_ShouldSuccessfullyAddTrailToVisited()
        {
            var user = new ApplicationUser
            {
                Id = "test2",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToVisitedAsync(user.Id, trail.TrailId);

            bool isVisited = user.SavedVisitedTrails
                .Any(t => t.TrailId == trail.TrailId && t.IsVisited == true);

            Assert.IsTrue(isVisited);
        }

        [Test]
        public async Task IsTrailVisitedByUserAsync_ShouldReturnTrueIfTrailIsVisited()
        {
            var user = new ApplicationUser
            {
                Id = "test3",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToVisitedAsync(user.Id, trail.TrailId);

            bool isVisited = await trailService.IsTrailVisitedByUserAsync(user.Id, trail.TrailId);

            Assert.IsTrue(isVisited);
        }

        [Test]
        public async Task IsTrailVisitedByUserAsync_ShouldReturnFalseIfTrailIsNotVisited()
        {
            var user = new ApplicationUser
            {
                Id = "test4",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            bool isVisited = await trailService.IsTrailVisitedByUserAsync(user.Id, trail.TrailId);

            Assert.IsFalse(isVisited);
        }

        [Test]
        public async Task AllTrailsByUserIdAsync_ShouldReturnEmptyCollectionIfNoTrailsSavedOrVisitedByUser()
        {
            var user = new ApplicationUser
            {
                Id = "test66",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trails = await trailService.AllTrailsByUserIdAsync(user.Id);

            Assert.That(trails.Count().Equals(user.SavedVisitedTrails.Count()));
        }

        [Test]
        public async Task AllTrailsByUserIdAsync_ShouldReturnCorrectValues()
        {
            var user = new ApplicationUser
            {
                Id = "test6",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToVisitedAsync(user.Id, trail.TrailId);

            var trails = await trailService.AllTrailsByUserIdAsync(user.Id);

            Assert.That(trails.Count().Equals(user.SavedVisitedTrails.Count()));
            Assert.That(trails.First().Name.Equals(user.SavedVisitedTrails.First().Trail.Name));
        }

        [Test]
        public async Task AllSavedTrailsByUserIdAsync_ShouldReturnEmptyCollectionIfNoTrailsSavedByUser()
        {
            var user = new ApplicationUser
            {
                Id = "test7",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trails = await trailService.AllSavedTrailsByUserIdAsync(user.Id);

            var expectedTrails = user.SavedVisitedTrails
                .Where(t => t.IsSaved == true);

            Assert.That(trails.Count().Equals(expectedTrails.Count()));
        }

        [Test]
        public async Task AllSavedTrailsByUserIdAsync_ShouldReturnCorrectValues()
        {
            var user = new ApplicationUser
            {
                Id = "test8",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToSavedAsync(user.Id, trail.TrailId);

            var trails = await trailService.AllSavedTrailsByUserIdAsync(user.Id);

            var expectedTrails = user.SavedVisitedTrails
                .Where(t => t.IsSaved == true);

            Assert.That(trails.Count().Equals(expectedTrails.Count()));
            Assert.That(trails.First().Name.Equals(expectedTrails.First().Trail.Name));
        }

        [Test]
        public async Task AllVisitedTrailsByUserIdAsync_ShouldReturnEmptyCollectionIfNoTrailsVisitedByUser()
        {
            var user = new ApplicationUser
            {
                Id = "test77",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trails = await trailService.AllVisitedTrailsByUserIdAsync(user.Id);

            var expectedTrails = user.SavedVisitedTrails
                .Where(t => t.IsVisited == true);

            Assert.That(trails.Count().Equals(expectedTrails.Count()));
        }

        [Test]
        public async Task AllVisitedTrailsByUserIdAsync_ShouldReturnCorrectValues()
        {
            var user = new ApplicationUser
            {
                Id = "test88",
                UserName = "test@test.com",
                PasswordHash = "test"
            };

            data.Users.Add(user);

            var trail = data.Trails.First();

            await trailService.AddTrailToVisitedAsync(user.Id, trail.TrailId);

            var trails = await trailService.AllVisitedTrailsByUserIdAsync(user.Id);

            var expectedTrails = user.SavedVisitedTrails
                .Where(t => t.IsVisited == true);

            Assert.That(trails.Count().Equals(expectedTrails.Count()));
            Assert.That(trails.First().Name.Equals(expectedTrails.First().Trail.Name));
        }

        [Test]
        public async Task FindTrailsByConditionsAsync_ShouldReturnAllTrailsIfNoConditionAdded()
        {
            int trailsCount = data.Trails.Count();

            var trails = await trailService.FindTrailsByConditionsAsync(null, null, null, null);

            Assert.That(trailsCount.Equals(trails.Count()));
        }

        [Test]
        public async Task FindTrailsByConditionsAsync_ShouldReturnAllTrailsByGivenRegion()
        {
            int regionId = 1;

            var expectedTrails = data.Trails.Where(t => t.RegionId == regionId);

            var trails = await trailService.FindTrailsByConditionsAsync(regionId, null, null, null);

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
        }

        [Test]
        public async Task FindTrailsByConditionsAsync_ShouldReturnAllTrailsByGivenDifficultyLevel()
        {

            var expectedTrails = data.Trails.Where(t => t.DifficultyLevel == DifficultyLevel.Difficult);

            var trails = await trailService.FindTrailsByConditionsAsync(null, DifficultyLevel.Difficult, null, null);

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
        }

        [Test]
        public async Task FindTrailsByConditionsAsync_ShouldReturnAllTrailsWithLessThanGivenDuration()
        {
            double duration = 3.5;
            int hours = (int)duration;
            int minutes = (int)((duration - hours) * 60);
            TimeSpan searchedDuration = new TimeSpan(hours, minutes, 0);

            var expectedTrails = data.Trails.Where(t => t.Duration <= searchedDuration);

            var trails = await trailService.FindTrailsByConditionsAsync(null, null, duration, null);

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
        }

        [Test]
        public async Task FindTrailsByConditionsAsync_ShouldReturnAllTrailsByGivenElevationGain()
        {
            int elevationGain = 1000;

            var expectedTrails = data.Trails.Where(t => t.ElevationGain <= elevationGain);

            var trails = await trailService.FindTrailsByConditionsAsync(null, null, null, elevationGain);

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
        }

        [Test]
        public async Task FindTrailsByConditionsAsync_ShouldReturnAllTrailsByGivenConditions()
        {
            int regionId = 1;

            double duration = 3.5;
            int hours = (int)duration;
            int minutes = (int)((duration - hours) * 60);
            TimeSpan searchedDuration = new TimeSpan(hours, minutes, 0);

            int elevationGain = 1000;

            var expectedTrails = data.Trails.Where(t => t.RegionId == regionId 
            && t.DifficultyLevel == DifficultyLevel.Difficult 
            && t.Duration <= searchedDuration
            && t.ElevationGain <= elevationGain);

            var trails = await trailService.FindTrailsByConditionsAsync(regionId, DifficultyLevel.Difficult, duration, elevationGain);

            Assert.That(expectedTrails.Count().Equals(trails.Count()));
        }


        [OneTimeTearDown]
        public void TearDownBase()
    => data.Dispose();
    }
}
