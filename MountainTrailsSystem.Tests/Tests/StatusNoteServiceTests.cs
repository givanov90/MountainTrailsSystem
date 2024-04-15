using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.StatusNote;
using MountainTrailsSystem.Core.Services;

namespace MountainTrailsSystem.Tests.Tests
{
    public class StatusNoteServiceTests : UnitTestsBase
    {
        private IStatusNoteService statusNoteService;

        [OneTimeSetUp]
        public void SetUp()
            => statusNoteService = new StatusNoteService(data);

        [Test]
        public async Task CreateStatusNoteAsync_ShouldCreateStatusNoteCorrectly()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var newStatusNote = data.TrailStatusNotes.Last();

            Assert.IsNotNull(newStatusNote);
            Assert.That(newStatusNote.Title.Equals(model.Title));
            Assert.That(newStatusNote.Description.Equals(model.Description));
        }

        [Test]
        public async Task IsStatusNotesNotResolvedAsync_ShouldReturnTrueWhenThereAreNewStatusNotes()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            bool notResolvedExists = await statusNoteService.IsStatusNotesNotResolvedAsync();

            Assert.IsTrue(notResolvedExists);
        }

        [Test]
        public async Task GetNotResolvedStatusNotesCountAsync_ShouldReturnCorrectCountWhenNoStatusNotesAdded()
        {
            int expectedCount = data.TrailStatusNotes
                .Where(sn => sn.IsResolved == false)
                .Count();

            int count = await statusNoteService.GetNotResolvedStatusNotesCountAsync();

            Assert.That(expectedCount.Equals(count));
        }

        [Test]
        public async Task GetNotResolvedStatusNotesCountAsync_ShouldReturnCorrectCountWhenStatusNotesAreAdded()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            int expectedCount = data.TrailStatusNotes
                .Where(sn => sn.IsResolved == false)
                .Count();

            int count = await statusNoteService.GetNotResolvedStatusNotesCountAsync();

            Assert.That(expectedCount.Equals(count));
        }

        [Test]
        public async Task AllStatusNotesAsListAsync_ShouldReturnEmptyCollectionWhenNoStatusNotesAreAdded()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNotes = await statusNoteService.AllStatusNotesAsListAsync();

            var expectedStatusNotes = data.TrailStatusNotes
                .Where(sn => sn.IsResolved == false)
                .ToList();

            Assert.That(expectedStatusNotes.Count.Equals(statusNotes.Count()));
            Assert.That(expectedStatusNotes.Last().Title.Equals(model.Title));
            Assert.That(expectedStatusNotes.Last().Description.Equals(model.Description));
        }

        [Test]
        public async Task AllStatusNotesAsListAsync_ShouldReturnCorrectCollectionWhenStatusNotesAreAdded()
        {
            var statusNotes = await statusNoteService.AllStatusNotesAsListAsync();

            int expectedCount = data.TrailStatusNotes
                .Where(sn => sn.IsResolved == false)
                .Count();

            Assert.That(expectedCount.Equals(statusNotes.Count()));
        }

        [Test]
        public async Task StatusNoteDetailsByIdAsync_ShouldReturnCorrectDetails()
        {
            int statusNoteId = 1;

            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNote = await statusNoteService.StatusNoteDetailsByIdAsync(statusNoteId);

            var expectedStatusNote = data.TrailStatusNotes
                .Where(sn => sn.TrailStatusNoteId == statusNoteId)
                .First();

            Assert.That(expectedStatusNote.Title.Equals(statusNote.Title));
            Assert.That(expectedStatusNote.Description.Equals(statusNote.Description));
        }

        [Test]
        public async Task ResolveStatusNoteAsync_ShouldResolveStatusNote()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNote = data.TrailStatusNotes.Last();

            await statusNoteService.ResolveStatusNoteAsync(statusNote.TrailStatusNoteId);

            Assert.IsTrue(statusNote.IsResolved);
        }

        [Test]
        public async Task IsStatusNoteResolvedAsync_ShouldReturnTrueWithResolvedStatusNote()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNote = data.TrailStatusNotes.Last();

            await statusNoteService.ResolveStatusNoteAsync(statusNote.TrailStatusNoteId);

            bool isResolved = await statusNoteService.IsStatusNoteResolvedAsync(statusNote.TrailStatusNoteId);

            Assert.IsTrue(isResolved);
        }

        [Test]
        public async Task IsStatusNoteResolvedAsync_ShouldReturnFalseWithNotResolvedStatusNote()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNote = data.TrailStatusNotes.Last();

            bool isResolved = await statusNoteService.IsStatusNoteResolvedAsync(statusNote.TrailStatusNoteId);

            Assert.IsFalse(isResolved);
        }

        [Test]
        public async Task StatusNoteExistsAsync_ShouldReturnTrueWithExistingStatusNote()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNote = data.TrailStatusNotes.Last();

            bool exists = await statusNoteService.StatusNoteExistsAsync(statusNote.TrailStatusNoteId);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task StatusNoteExistsAsync_ShouldReturnFalseWithNonExistingStatusNote()
        {
            int statusNoteId = 1111111111;

            bool exists = await statusNoteService.StatusNoteExistsAsync(statusNoteId);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetTrailByStatusNoteIdAsync_ShouldReturnCorrectTrailId()
        {
            var model = new TrailStatusNoteViewModel
            {
                Title = "Missing marking",
                Description = "The trail is not clearly visible, as it is missing marking on the two thirds of it.",
                TrailId = 1,
                ImageUrl = "https://photos.thetrek.co/wp-content/uploads/2023/04/12082507/IMG_7896-scaled.jpeg"
            };

            await statusNoteService.CreateStatusNoteAsync(model);

            var statusNote = data.TrailStatusNotes.Last();

            int trailId = await statusNoteService.GetTrailByStatusNoteIdAsync(statusNote.TrailStatusNoteId);

            int expectedId = statusNote.TrailId;

            Assert.That(expectedId.Equals(trailId));
        }

        [OneTimeTearDown]
        public void TearDownBase()
            => data.Dispose();
    }
}
