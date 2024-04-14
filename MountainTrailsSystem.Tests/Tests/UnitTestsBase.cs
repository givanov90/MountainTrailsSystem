using Microsoft.AspNetCore.Identity;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Infrastructure.Enumerations;
using MountainTrailsSystem.Tests.Mocks;

namespace MountainTrailsSystem.Tests.Tests
{
    public class UnitTestsBase
    {
        protected MountainTrailsSystemDbContext data;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            data = DatabaseMock.Instance;
            SeedDatabase();
        }

        public ApplicationUser Administrator { get; set; }

        public Region SofiaRegion { get; set; }

        public Region BlagoevgradRegion { get; set; }

        public Region KyustendilRegion { get; set; }

        public Region PazardjikRegion { get; set; }

        public Region SmolyanRegion { get; set; }

        public Region KardzhaliRegion { get; set; }

        public Mountain RilaMountain { get; set; }

        public Mountain PirinMountain { get; set; }

        public Mountain VitoshaMountain { get; set; }

        public Mountain RodopiMountain { get; set; }

        public MountainRegion RilaSofia { get; set; }

        public MountainRegion RilaBlagoevgrad { get; set; }

        public MountainRegion RilaKyustendil { get; set; }

        public MountainRegion RodopiPazardjik { get; set; }

        public MountainRegion RodopiSmolyan { get; set; }

        public MountainRegion RodopiKardzhali { get; set; }

        public MountainRegion PirinBlagoevgrad { get; set; }

        public MountainRegion VitoshaSofia { get; set; }

        public Peak OstretsPeak { get; set; }

        public Peak MalyovitsaPeak { get; set; }

        public Peak KamenitzaPeak { get; set; }

        public Peak CherniVrahPeak { get; set; }

        public Trail VelingradOstretsPeakTrail { get; set; }

        public Trail SvetaPetkaOstretsPeakTrail { get; set; }

        public Trail MalyovitsaHutMalyovitsaPeakTrail { get; set; }

        public Trail IvanVazovHutMalyovitsaPeakTrail { get; set; }

        public Trail RilaMonasteryMalyovitsaPeakTrail { get; set; }

        public Trail TevnoEzeroShelterKamenitzaPeakTrail { get; set; }

        public Trail BegovitsaHutKamenitzaPeakTrail { get; set; }

        public Trail BezbogHutKamenitzaPeakTrail { get; set; }

        public Trail AlekoHutCherniVrahPeakTrail { get; set; }

        public Trail ZheleznitsaCherniVrahPeakTrail { get; set; }

        public Trail ZlatniteMostoveCherniVrahPeakTrail { get; set; }

        public TrailPeak VelingradOstretsTrailPeak { get; set; }

        public TrailPeak SvetaPetkaOstretsTrailPeak { get; set; }

        public TrailPeak MalyovitsaHutMalyovitsaTrailPeak { get; set; }

        public TrailPeak IvanVazovHutMalyovitsaTrailPeak { get; set; }

        public TrailPeak RilaMonasteryMalyovitsaTrailPeak { get; set; }

        public TrailPeak TevnoEzeroShelterKamenitzaTrailPeak { get; set; }

        public TrailPeak BegovitsaHutKamenitzaTrailPeak { get; set; }

        public TrailPeak BezbogHutKamenitzaTrailPeak { get; set; }

        public TrailPeak AlekoHutCherniVrahTrailPeak { get; set; }

        public TrailPeak ZheleznitsaCherniVrahTrailPeak { get; set; }

        public TrailPeak ZlatniteMostoveCherniVrahTrailPeak { get; set; }

        private void SeedDatabase()
        {
            SeedAdministrator();
            SeedRegions();
            SeedMountains();
            SeedMountainRegions();
            SeedPeaks();
            SeedTrails();
            SeedTrailPeaks();

            data.Users.Add(Administrator);

            data.Regions.Add(SofiaRegion);
            data.Regions.Add(BlagoevgradRegion);
            data.Regions.Add(KyustendilRegion);
            data.Regions.Add(PazardjikRegion);
            data.Regions.Add(SmolyanRegion);
            data.Regions.Add(KardzhaliRegion);

            data.Mountains.Add(RilaMountain);
            data.Mountains.Add(PirinMountain);
            data.Mountains.Add(VitoshaMountain);
            data.Mountains.Add(RodopiMountain);

            data.MountainsRegions.Add(RilaSofia);
            data.MountainsRegions.Add(RilaBlagoevgrad);
            data.MountainsRegions.Add(RilaKyustendil);
            data.MountainsRegions.Add(RodopiPazardjik);
            data.MountainsRegions.Add(RodopiSmolyan);
            data.MountainsRegions.Add(RodopiKardzhali);
            data.MountainsRegions.Add(PirinBlagoevgrad);
            data.MountainsRegions.Add(VitoshaSofia);

            data.Peaks.Add(OstretsPeak);
            data.Peaks.Add(MalyovitsaPeak);
            data.Peaks.Add(KamenitzaPeak);
            data.Peaks.Add(CherniVrahPeak);

            data.Trails.Add(VelingradOstretsPeakTrail);
            data.Trails.Add(SvetaPetkaOstretsPeakTrail);
            data.Trails.Add(MalyovitsaHutMalyovitsaPeakTrail);
            data.Trails.Add(IvanVazovHutMalyovitsaPeakTrail);
            data.Trails.Add(RilaMonasteryMalyovitsaPeakTrail);
            data.Trails.Add(TevnoEzeroShelterKamenitzaPeakTrail);
            data.Trails.Add(BegovitsaHutKamenitzaPeakTrail);
            data.Trails.Add(BezbogHutKamenitzaPeakTrail);
            data.Trails.Add(AlekoHutCherniVrahPeakTrail);
            data.Trails.Add(ZheleznitsaCherniVrahPeakTrail);
            data.Trails.Add(ZlatniteMostoveCherniVrahPeakTrail);

            data.TrailsPeaks.Add(VelingradOstretsTrailPeak);
            data.TrailsPeaks.Add(SvetaPetkaOstretsTrailPeak);
            data.TrailsPeaks.Add(MalyovitsaHutMalyovitsaTrailPeak);
            data.TrailsPeaks.Add(IvanVazovHutMalyovitsaTrailPeak);
            data.TrailsPeaks.Add(RilaMonasteryMalyovitsaTrailPeak);
            data.TrailsPeaks.Add(TevnoEzeroShelterKamenitzaTrailPeak);
            data.TrailsPeaks.Add(BegovitsaHutKamenitzaTrailPeak);
            data.TrailsPeaks.Add(BezbogHutKamenitzaTrailPeak);
            data.TrailsPeaks.Add(AlekoHutCherniVrahTrailPeak);
            data.TrailsPeaks.Add(ZheleznitsaCherniVrahTrailPeak);
            data.TrailsPeaks.Add(ZlatniteMostoveCherniVrahTrailPeak);

            data.SaveChanges();
        }

        private DateTime seedDate = new DateTime(2024, 4, 1);
        private void SeedAdministrator()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            Administrator = new ApplicationUser()
            {
                Id = "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                UserName = "admin@mts.com",
                NormalizedUserName = "ADMIN@MTS.COM",
                Email = "admin@mts.com",
                NormalizedEmail = "ADMIN@MTS.COM"
            };

            Administrator.PasswordHash =
            hasher.HashPassword(Administrator, "admin1369");
        }

        private void SeedRegions()
        {
            SofiaRegion = new Region()
            {
                RegionId = 1,
                Name = "Sofia",
            };

            BlagoevgradRegion = new Region()
            {
                RegionId = 2,
                Name = "Blagoevgrad",
            };

            KyustendilRegion = new Region()
            {
                RegionId = 3,
                Name = "Kyustendil",
            };

            PazardjikRegion = new Region()
            {
                RegionId = 4,
                Name = "Pazardjik",
            };

            SmolyanRegion = new Region()
            {
                RegionId = 5,
                Name = "Smolyan",
            };

            KardzhaliRegion = new Region()
            {
                RegionId = 6,
                Name = "Kardzhali",
            };
        }

        private void SeedMountains()
        {
            RilaMountain = new Mountain()
            {
                Id = 1,
                Name = "Rila",
            };

            PirinMountain = new Mountain()
            {
                Id = 2,
                Name = "Pirin",
            };

            VitoshaMountain = new Mountain()
            {
                Id = 3,
                Name = "Vitosha",
            };

            RodopiMountain = new Mountain()
            {
                Id = 4,
                Name = "Rodopi",
            };
        }

        private void SeedMountainRegions()
        {
            RilaSofia = new MountainRegion()
            {
                MountainId = 1,
                RegionId = 1,
            };

            RilaBlagoevgrad = new MountainRegion()
            {
                MountainId = 1,
                RegionId = 2,
            };

            RilaKyustendil = new MountainRegion()
            {
                MountainId = 1,
                RegionId = 3,
            };

            RodopiPazardjik = new MountainRegion()
            {
                MountainId = 4,
                RegionId = 4,
            };

            RodopiSmolyan = new MountainRegion()
            {
                MountainId = 4,
                RegionId = 5,
            };

            RodopiKardzhali = new MountainRegion()
            {
                MountainId = 4,
                RegionId = 6,
            };

            PirinBlagoevgrad = new MountainRegion()
            {
                MountainId = 2,
                RegionId = 2,
            };

            VitoshaSofia = new MountainRegion()
            {
                MountainId = 3,
                RegionId = 1,
            };
        }

        private void SeedPeaks()
        {
            OstretsPeak = new Peak()
            {
                PeakId = 1,
                Name = "Ostrets",
                Elevation = 1369,
                MountainId = RodopiMountain.Id,
                ImageUrl = "https://www.hotelmap.bg/uploads/images/gallery/fd0f5b5cc57d7316b39a953540707930o5.jpg",
                Description = "Ostrets Peak near Velingrad, Bulgaria, boasts stunning natural beauty and panoramic views. Nestled in the Rhodope Mountains, it offers lush forests, hiking trails, and diverse wildlife. Hikers can enjoy reaching the summit for breathtaking vistas of valleys and peaks, making it a favorite for nature lovers.",
            };

            MalyovitsaPeak = new Peak()
            {
                PeakId = 2,
                Name = "Malyovitsa",
                Elevation = 2729,
                MountainId = RilaMountain.Id,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Maliovitsa_54072.jpg/1280px-Maliovitsa_54072.jpg",
                Description = "Malyovitsa Peak, a striking summit in the Rila Mountains of Bulgaria, is renowned for its dramatic beauty and challenging hiking trails. Surrounded by pristine wilderness, it offers breathtaking views of rugged landscapes and alpine meadows. A favorite destination for outdoor enthusiasts, Malyovitsa Peak provides an unforgettable adventure in the heart of nature."
            };

            KamenitzaPeak = new Peak()
            {
                PeakId = 3,
                Name = "Kamenitza",
                Elevation = 2824,
                MountainId = PirinMountain.Id,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Kamenitsa_Pirin_IMG_2731.jpg/1280px-Kamenitsa_Pirin_IMG_2731.jpg",
                Description = "Kamenitza Peak, nestled in the Pirin Mountains of Bulgaria, is famed for its majestic beauty and rugged terrain.Trekkers are drawn to its challenging trails and stunning vistas of alpine landscapes.Surrounded by pristine wilderness, Kamenitza Peak offers an exhilarating adventure for nature lovers seeking scenic beauty and outdoor exploration.",
            };

            CherniVrahPeak = new Peak()
            {
                PeakId = 4,
                Name = "Cherni vrah",
                Elevation = 2290,
                MountainId = VitoshaMountain.Id,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Cherni_Vrah_Vitosha_07.jpg/1280px-Cherni_Vrah_Vitosha_07.jpg",
                Description = "Cherni Vrah Peak, the highest point in Vitosha Mountain near Sofia, Bulgaria, offers breathtaking panoramic views and diverse flora and fauna. Popular among hikers, it features well-marked trails and stunning rock formations, providing an unforgettable outdoor experience amidst pristine nature."
            };
        }

        private void SeedTrails()
        {
            VelingradOstretsPeakTrail = new Trail()
            {
                TrailId = 1,
                Name = "Velingrad - Ostrets peak",
                Description = "The trail from Velingrad to Ostrets Peak winds through the picturesque Rhodope Mountains, offering a captivating journey for nature enthusiasts. Beginning in the charming town of Velingrad, known for its mineral springs, the trail gradually ascends through lush forests and meandering streams. As hikers ascend, they are treated to breathtaking vistas of the surrounding valleys and peaks. Along the way, diverse flora and fauna dot the landscape, providing ample opportunities for birdwatching and wildlife spotting. The trail is well-marked and relatively moderate in difficulty, making it accessible to hikers of varying skill levels. Upon reaching Ostrets Peak, adventurers are rewarded with panoramic views that stretch as far as the eye can see, making the journey from Velingrad a truly unforgettable experience in the heart of nature.",
                DifficultyLevel = DifficultyLevel.Moderate,
                Duration = new TimeSpan(3, 0, 0),
                Distance = 7.5,
                ElevationGain = 600,
                MountainId = RodopiMountain.Id,
                LastUpdated = seedDate,
                RegionId = PazardjikRegion.RegionId,
                ImageUrl = "https://www.hotelmap.bg/uploads/images/gallery/2aab94d31ff1c1a83feec06c3bb722b9o2.jpg",
            };

            SvetaPetkaOstretsPeakTrail = new Trail()
            {
                TrailId = 2,
                Name = "Sveta Petka Village - Ostrets peak",
                Description = "The trail from Sveta Petka to Ostrets Peak offers a captivating journey through the scenic beauty of the Rhodope Mountains in Bulgaria. Starting at the quaint village of Sveta Petka, the trail meanders through lush forests, tranquil meadows, and rocky terrain. Along the way, hikers are treated to panoramic views of the surrounding valleys and peaks, providing ample opportunities for photography and contemplation. The trail is well-maintained but can be challenging in parts, with steep ascents and descents. However, the effort is rewarded with the stunning natural landscapes and the sense of accomplishment upon reaching Ostrets Peak. At the summit, adventurers are greeted with breathtaking vistas that stretch as far as the eye can see, making the journey from Sveta Petka an unforgettable outdoor experience.",
                DifficultyLevel = DifficultyLevel.Easy,
                Duration = new TimeSpan(2, 0, 0),
                Distance = 5.2,
                ElevationGain = 360,
                MountainId = RodopiMountain.Id,
                LastUpdated = seedDate,
                RegionId = PazardjikRegion.RegionId,
                ImageUrl = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjZbKuVC8Wp7jV29Wl2FBZABOq87KP5S9W1ot5Q-keCnleh31N3MtM1HottF4hvKvHjnUN8_n8evU_TFEMevjoxPMuIlNDjC_mKbdaPHnMzxJ1Hz4edohwFMoxpXf0Y5eLTx06WADZ0sE0/s1600/22.jpg",
            };

            MalyovitsaHutMalyovitsaPeakTrail = new Trail()
            {
                TrailId = 3,
                Name = "Malyovitsa hut - Malyovitsa peak",
                Description = "The trail from Malyovitsa Hut to Malyovitsa Peak in the Rila Mountains of Bulgaria offers a captivating adventure amidst stunning alpine scenery. Beginning at the cozy Malyovitsa Hut, nestled in a picturesque valley, the trail ascends gradually through dense forests and rocky slopes. Along the way, hikers are treated to breathtaking views of towering peaks and rugged landscapes. The trail is well-marked and relatively moderate in difficulty, making it accessible to hikers of varying skill levels. As the ascent continues, the scenery becomes increasingly dramatic, with jagged cliffs and cascading waterfalls adding to the allure of the surroundings. Finally, upon reaching the summit of Malyovitsa Peak, adventurers are rewarded with panoramic vistas that stretch as far as the eye can see, offering a sense of accomplishment and awe-inspiring beauty. Whether it's the challenge of the hike or the beauty of the natural surroundings, the trail from Malyovitsa Hut to Malyovitsa Peak promises an unforgettable outdoor experience in the heart of the Rila Mountains.",
                DifficultyLevel = DifficultyLevel.Difficult,
                Duration = new TimeSpan(3, 0, 0),
                Distance = 8.1,
                ElevationGain = 860,
                MountainId = RilaMountain.Id,
                LastUpdated = seedDate,
                RegionId = SofiaRegion.RegionId,
                ImageUrl = "https://tripsjournal.com/wp-content/uploads/2017/09/11-vryh-malyovitsa.jpg",
            };

            IvanVazovHutMalyovitsaPeakTrail = new Trail()
            {
                TrailId = 4,
                Name = "Ivan Vazov hut - Malyovitsa peak",
                Description = "The trail from Ivan Vazov Hut to Malyovitsa Peak in Bulgaria's Rila Mountains offers a thrilling journey through diverse landscapes. Starting at the charming Ivan Vazov Hut, nestled amidst lush forests, the trail gradually ascends through alpine meadows and rocky terrain. Hikers are treated to breathtaking views of towering peaks and serene valleys along the way. The trail is well-marked but can be challenging, with steep sections demanding endurance and agility. As the ascent progresses, the scenery becomes increasingly dramatic, with rugged cliffs and cascading streams adding to the allure. Upon reaching the summit of Malyovitsa Peak, adventurers are rewarded with awe-inspiring vistas stretching as far as the eye can see. Whether seeking adventure or tranquility, the trail from Ivan Vazov Hut to Malyovitsa Peak promises an unforgettable outdoor experience amidst the natural splendor of the Rila Mountains.",
                DifficultyLevel = DifficultyLevel.Difficult,
                Duration = new TimeSpan(4, 30, 0),
                Distance = 10.3,
                ElevationGain = 770,
                MountainId = RilaMountain.Id,
                LastUpdated = seedDate,
                RegionId = SofiaRegion.RegionId,
                ImageUrl = "https://tabakoff.eu/wp/wp-content/uploads/2016/09/DSC_0063.jpg",
            };

            RilaMonasteryMalyovitsaPeakTrail = new Trail()
            {
                TrailId = 5,
                Name = "Rila Monastery - Malyovitsa peak",
                Description = "The trail from Rila Monastery to Malyovitsa Peak offers a captivating journey through the stunning landscapes of the Rila Mountains in Bulgaria. Beginning at the historic Rila Monastery, a UNESCO World Heritage site, the trail winds through picturesque valleys and dense forests, providing glimpses of cultural and natural heritage along the way. As hikers ascend, the scenery transitions to alpine meadows and rocky slopes, with panoramic views of majestic peaks unfolding before them. The trail is well-marked but challenging, with steep sections demanding endurance and determination. However, the effort is rewarded with breathtaking vistas of the surrounding wilderness and the sense of accomplishment upon reaching Malyovitsa Peak. At the summit, adventurers are greeted with sweeping panoramas that showcase the beauty and grandeur of the Rila Mountains. Whether seeking adventure or spiritual rejuvenation, the trail from Rila Monastery to Malyovitsa Peak promises an unforgettable outdoor experience immersed in the natural splendor of Bulgaria's mountainous landscape.",
                DifficultyLevel = DifficultyLevel.VeryDifficult,
                Duration = new TimeSpan(6, 0, 0),
                Distance = 12.2,
                ElevationGain = 1500,
                MountainId = RilaMountain.Id,
                LastUpdated = seedDate,
                RegionId = KyustendilRegion.RegionId,
                ImageUrl = "https://iskamdaletya.com/wp-content/uploads/2018/08/IMG_5475_edited-e1535716578693.jpg",
            };

            TevnoEzeroShelterKamenitzaPeakTrail = new Trail()
            {
                TrailId = 6,
                Name = "Tevno ezero shelter - Kamenitza peak",
                Description = "The trail from Tevno Ezero Shelter to Kamenitza Peak in Bulgaria's Pirin Mountains offers a captivating journey through pristine alpine scenery. Starting at the tranquil Tevno Ezero Shelter, nestled beside a picturesque lake, the trail leads hikers through dense forests and meandering streams. As the ascent begins, the landscape transforms into rocky terrain, dotted with vibrant alpine flora. The trail is well-marked but challenging, with steep sections demanding endurance and careful footing. Along the way, hikers are rewarded with breathtaking views of jagged peaks and serene valleys, providing ample opportunities for photography and reflection. As the trail nears Kamenitza Peak, the scenery becomes increasingly dramatic, with towering cliffs and rugged ridges dominating the horizon. Upon reaching the summit, adventurers are greeted with panoramic vistas that stretch as far as the eye can see, offering a sense of accomplishment and awe-inspiring beauty. Whether seeking adventure or tranquility, the trail from Tevno Ezero Shelter to Kamenitza Peak promises an unforgettable outdoor experience amidst the natural splendor of the Pirin Mountains.",
                DifficultyLevel = DifficultyLevel.Difficult,
                Duration = new TimeSpan(3, 0, 0),
                Distance = 6.4,
                ElevationGain = 600,
                MountainId = PirinMountain.Id,
                LastUpdated = seedDate,
                RegionId = BlagoevgradRegion.RegionId,
                ImageUrl = "https://bulgarian-photography.com/UserFiles/pictures/BACEEBE3-8BA4-C931-9AE6-A95F97110DCD.jpg",
            };

            BegovitsaHutKamenitzaPeakTrail = new Trail()
            {
                TrailId = 7,
                Name = "Begovitsa hut - Kamenitza peak",
                Description = "The trail from Begovitsa Hut to Kamenitza Peak in Bulgaria's Pirin Mountains is a breathtaking journey through pristine wilderness. Beginning at the charming Begovitsa Hut, nestled amidst lush forests and meadows, the trail gradually ascends through diverse landscapes. Hikers traverse winding paths, crossing crystal-clear streams and ascending rocky slopes. Along the way, the scenery unfolds in a symphony of colors, with vibrant alpine flora lining the trail. The route is well-marked but challenging, with steep sections requiring careful navigation. As hikers ascend, panoramic vistas of towering peaks and deep valleys reward their efforts. Approaching Kamenitza Peak, the landscape becomes increasingly dramatic, with rugged cliffs and rocky outcrops dominating the skyline. At the summit, adventurers are greeted with awe-inspiring views that stretch as far as the eye can see, providing a sense of accomplishment and connection with nature. Whether seeking adventure or tranquility, the trail from Begovitsa Hut to Kamenitza Peak promises an unforgettable outdoor experience amidst the natural splendor of the Pirin Mountains.",
                DifficultyLevel = DifficultyLevel.Moderate,
                Duration = new TimeSpan(3, 30, 0),
                Distance = 8.1,
                ElevationGain = 1000,
                MountainId = PirinMountain.Id,
                LastUpdated = seedDate,
                RegionId = BlagoevgradRegion.RegionId,
                ImageUrl = "https://qbylkovcvqt.blog.bg/photos/31305/552.JPG",
            };

            BezbogHutKamenitzaPeakTrail = new Trail()
            {
                TrailId = 8,
                Name = "Bezbog hut - Kamenitza peak",
                Description = "The trail from Bezbog Hut to Kamenitza Peak in Bulgaria's Pirin Mountains offers an exhilarating adventure through stunning alpine landscapes. Beginning at Bezbog Hut, nestled amid picturesque meadows and forests, the trail ascends gradually, revealing panoramic vistas of rugged peaks and deep valleys. Hikers traverse diverse terrain, from lush forests to rocky slopes, with occasional glimpses of pristine alpine lakes. The well-marked trail presents moderate challenges, with some steep sections requiring careful footing. Along the way, hikers are rewarded with sightings of diverse flora and fauna, adding to the allure of the journey. As the ascent progresses, the scenery becomes increasingly dramatic, with towering cliffs and jagged ridges dominating the horizon. Approaching Kamenitza Peak, the trail offers breathtaking views of the surrounding wilderness, culminating in a sense of accomplishment upon reaching the summit. At the peak, adventurers are treated to awe-inspiring vistas that stretch as far as the eye can see, providing a memorable conclusion to the outdoor experience. Whether seeking adventure or tranquility, the trail from Bezbog Hut to Kamenitza Peak promises an unforgettable journey through the natural splendor of the Pirin Mountains.",
                DifficultyLevel = DifficultyLevel.Difficult,
                Duration = new TimeSpan(5, 30, 0),
                Distance = 10.6,
                ElevationGain = 930,
                MountainId = PirinMountain.Id,
                LastUpdated = seedDate,
                RegionId = BlagoevgradRegion.RegionId,
                ImageUrl = "https://kostadinnikolov.com/wp-content/uploads/2020/10/IMG_20200829_111234.jpg",
            };

            AlekoHutCherniVrahPeakTrail = new Trail()
            {
                TrailId = 9,
                Name = "Aleko hut - Cherni vrah peak",
                Description = "The trail from Aleko Hut to Cherni Vrah Peak in Bulgaria's Vitosha Mountain offers a thrilling adventure through diverse landscapes. Starting at Aleko Hut, nestled amidst lush forests and meadows, the trail ascends steadily, providing stunning views of the surrounding valleys and peaks. Hikers navigate well-marked paths, passing through rocky terrain and alpine meadows adorned with colorful wildflowers. The trail presents moderate challenges, with occasional steep sections requiring careful footing. Along the way, hikers encounter unique flora and fauna, adding to the charm of the journey. As the ascent progresses, the scenery becomes increasingly dramatic, with rocky outcrops and rugged cliffs dominating the landscape. Approaching Cherni Vrah Peak, the trail offers breathtaking panoramas of the surrounding wilderness, culminating in a sense of accomplishment upon reaching the summit. At the peak, adventurers are rewarded with awe-inspiring vistas that stretch as far as the eye can see, providing a memorable conclusion to the outdoor experience. Whether seeking adventure or tranquility, the trail from Aleko Hut to Cherni Vrah Peak promises an unforgettable journey through the natural beauty of Vitosha Mountain.",
                DifficultyLevel = DifficultyLevel.Easy,
                Duration = new TimeSpan(1, 30, 0),
                Distance = 2.9,
                ElevationGain = 480,
                MountainId = VitoshaMountain.Id,
                LastUpdated = seedDate,
                RegionId = SofiaRegion.RegionId,
                ImageUrl = "https://tripsjournal.com/wp-content/uploads/2016/03/cherni-vrah.jpg",
            };

            ZheleznitsaCherniVrahPeakTrail = new Trail()
            {
                TrailId = 10,
                Name = "Zheleznitsa - Cherni vrah peak",
                Description = "The trail from Zheleznitsa to Cherni Vrah Peak in Bulgaria's Vitosha Mountain offers an exhilarating hike through diverse landscapes. Beginning in the charming village of Zheleznitsa, the trail winds through lush forests and meadows, gradually ascending towards the summit. Hikers traverse well-marked paths, encountering rocky terrain and alpine flora along the way. The trail presents moderate challenges, with some steep sections demanding careful navigation. As the ascent continues, the scenery becomes increasingly dramatic, with panoramic views of the surrounding valleys and peaks unfolding before hikers' eyes. Approaching Cherni Vrah Peak, the trail offers breathtaking vistas of the rugged landscape, culminating in a sense of achievement upon reaching the summit. At the peak, adventurers are treated to sweeping panoramas that stretch as far as the eye can see, providing a memorable conclusion to the hike. Whether seeking adventure or tranquility, the trail from Zheleznitsa to Cherni Vrah Peak promises an unforgettable outdoor experience immersed in the natural beauty of Vitosha Mountain.",
                DifficultyLevel = DifficultyLevel.Difficult,
                Duration = new TimeSpan(4, 30, 0),
                Distance = 9.9,
                ElevationGain = 1320,
                MountainId = VitoshaMountain.Id,
                LastUpdated = seedDate,
                RegionId = SofiaRegion.RegionId,
                ImageUrl = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiB8-MfRFKr_g1aXDIFhZWC16NwDeeETLTmq3tVFua_qUCUnaRR0J4I-SN2AM9eLl6rdmXNgVQ30Zu1jix7zRIbmjpyFsWyQhBKnxMzM0QwgHo8MG2xeQ4AilpPUMVbNrH3r0Vr-4wZaVc/s1600/1.jpg",
            };

            ZlatniteMostoveCherniVrahPeakTrail = new Trail()
            {
                TrailId = 11,
                Name = "Zlatnite mostove - Cherni vrah peak",
                Description = "The trail from Zlatnite Mostove (The Golden Bridges) to Cherni Vrah Peak in Bulgaria's Vitosha Mountain is a breathtaking journey through rugged terrain and stunning vistas. Beginning at the iconic Golden Bridges, where massive rock formations span a mountain river, the trail winds through lush forests and rocky slopes. Hikers traverse well-marked paths, encountering diverse flora and fauna along the way. The trail presents moderate challenges, with occasional steep sections demanding careful footing. As the ascent progresses, the scenery becomes increasingly dramatic, with panoramic views of the surrounding valleys and peaks unfolding before hikers' eyes. Approaching Cherni Vrah Peak, the trail offers awe-inspiring vistas of the rugged landscape, culminating in a sense of achievement upon reaching the summit. At the peak, adventurers are rewarded with sweeping panoramas that stretch as far as the eye can see, providing a memorable conclusion to the hike. Whether seeking adventure or tranquility, the trail from Zlatnite Mostove to Cherni Vrah Peak promises an unforgettable outdoor experience immersed in the natural beauty of Vitosha Mountain.",
                DifficultyLevel = DifficultyLevel.Moderate,
                Duration = new TimeSpan(2, 50, 0),
                Distance = 6.4,
                ElevationGain = 800,
                MountainId = VitoshaMountain.Id,
                LastUpdated = seedDate,
                RegionId = SofiaRegion.RegionId,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/E3_%D0%97%D0%BB%D0%B0%D1%82%D0%BD%D0%B8%D1%82%D0%B5_%D0%BC%D0%BE%D1%81%D1%82%D0%BE%D0%B2%D0%B5.jpg/1280px-E3_%D0%97%D0%BB%D0%B0%D1%82%D0%BD%D0%B8%D1%82%D0%B5_%D0%BC%D0%BE%D1%81%D1%82%D0%BE%D0%B2%D0%B5.jpg",
            };
        }

        private void SeedTrailPeaks()
        {
            VelingradOstretsTrailPeak = new TrailPeak()
            {
                TrailId = 1,
                PeakId = 1,
            };

            SvetaPetkaOstretsTrailPeak = new TrailPeak()
            {
                TrailId = 2,
                PeakId = 1,
            };

            MalyovitsaHutMalyovitsaTrailPeak = new TrailPeak()
            {
                TrailId = 3,
                PeakId = 2,
            };

            IvanVazovHutMalyovitsaTrailPeak = new TrailPeak()
            {
                TrailId = 4,
                PeakId = 2,
            };

            RilaMonasteryMalyovitsaTrailPeak = new TrailPeak()
            {
                TrailId = 5,
                PeakId = 2,
            };

            TevnoEzeroShelterKamenitzaTrailPeak = new TrailPeak()
            {
                TrailId = 6,
                PeakId = 3,
            };

            BegovitsaHutKamenitzaTrailPeak = new TrailPeak()
            {
                TrailId = 7,
                PeakId = 3,
            };

            BezbogHutKamenitzaTrailPeak = new TrailPeak()
            {
                TrailId = 8,
                PeakId = 3,
            };

            AlekoHutCherniVrahTrailPeak = new TrailPeak()
            {
                TrailId = 9,
                PeakId = 4,
            };

            ZheleznitsaCherniVrahTrailPeak = new TrailPeak()
            {
                TrailId = 10,
                PeakId = 4,
            };

            ZlatniteMostoveCherniVrahTrailPeak = new TrailPeak()
            {
                TrailId = 11,
                PeakId = 4,
            };
        }

        [OneTimeTearDown]
        public void TearDownBase()
            => data.Dispose();
    }
}
