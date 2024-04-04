using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0", 0, "c7a74805-4ea3-47e3-91b4-b9e9e8549bde", "admin@mts.com", false, false, null, "ADMIN@MTS.COM", "ADMIN@MTS.COM", "AQAAAAEAACcQAAAAEFPkST1x5V8oCZDgrWHS0MKAQ3693QUhOjgIbhPJWcPAXqan0U6TYrK5PLSS7ftG8Q==", null, false, "965b7793-d8a9-4303-9b95-6a9ac93754ae", false, "admin@mts.com" });

            migrationBuilder.InsertData(
                table: "Mountains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rila" },
                    { 2, "Pirin" },
                    { 3, "Vitosha" },
                    { 4, "Rodopi" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Blagoevgrad" },
                    { 3, "Kyustendil" },
                    { 4, "Pazardjik" },
                    { 5, "Smolyan" },
                    { 6, "Kardzhali" }
                });

            migrationBuilder.InsertData(
                table: "MountainsRegions",
                columns: new[] { "MountainId", "RegionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "Peaks",
                columns: new[] { "PeakId", "Description", "Elevation", "ImageUrl", "MountainId", "Name" },
                values: new object[,]
                {
                    { 1, "Ostrets Peak near Velingrad, Bulgaria, boasts stunning natural beauty and panoramic views. Nestled in the Rhodope Mountains, it offers lush forests, hiking trails, and diverse wildlife. Hikers can enjoy reaching the summit for breathtaking vistas of valleys and peaks, making it a favorite for nature lovers.", 1369, "https://www.hotelmap.bg/uploads/images/gallery/fd0f5b5cc57d7316b39a953540707930o5.jpg", 4, "Ostrets" },
                    { 2, "Malyovitsa Peak, a striking summit in the Rila Mountains of Bulgaria, is renowned for its dramatic beauty and challenging hiking trails. Surrounded by pristine wilderness, it offers breathtaking views of rugged landscapes and alpine meadows. A favorite destination for outdoor enthusiasts, Malyovitsa Peak provides an unforgettable adventure in the heart of nature.", 2729, "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Maliovitsa_54072.jpg/1280px-Maliovitsa_54072.jpg", 1, "Malyovitsa" },
                    { 3, "Kamenitza Peak, nestled in the Pirin Mountains of Bulgaria, is famed for its majestic beauty and rugged terrain.Trekkers are drawn to its challenging trails and stunning vistas of alpine landscapes.Surrounded by pristine wilderness, Kamenitza Peak offers an exhilarating adventure for nature lovers seeking scenic beauty and outdoor exploration.", 2824, "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Kamenitsa_Pirin_IMG_2731.jpg/1280px-Kamenitsa_Pirin_IMG_2731.jpg", 2, "Kamenitza" },
                    { 4, "Cherni Vrah Peak, the highest point in Vitosha Mountain near Sofia, Bulgaria, offers breathtaking panoramic views and diverse flora and fauna. Popular among hikers, it features well-marked trails and stunning rock formations, providing an unforgettable outdoor experience amidst pristine nature.", 2290, "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Cherni_Vrah_Vitosha_07.jpg/1280px-Cherni_Vrah_Vitosha_07.jpg", 3, "Cherni vrah" }
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Description", "DifficultyLevel", "Distance", "Duration", "ElevationGain", "ImageUrl", "LastUpdated", "MountainId", "Name", "Rating", "RegionId" },
                values: new object[,]
                {
                    { 1, "The trail from Velingrad to Ostrets Peak winds through the picturesque Rhodope Mountains, offering a captivating journey for nature enthusiasts. Beginning in the charming town of Velingrad, known for its mineral springs, the trail gradually ascends through lush forests and meandering streams. As hikers ascend, they are treated to breathtaking vistas of the surrounding valleys and peaks. Along the way, diverse flora and fauna dot the landscape, providing ample opportunities for birdwatching and wildlife spotting. The trail is well-marked and relatively moderate in difficulty, making it accessible to hikers of varying skill levels. Upon reaching Ostrets Peak, adventurers are rewarded with panoramic views that stretch as far as the eye can see, making the journey from Velingrad a truly unforgettable experience in the heart of nature.", 1, 7.5, new TimeSpan(0, 3, 0, 0, 0), 600, "https://www.hotelmap.bg/uploads/images/gallery/2aab94d31ff1c1a83feec06c3bb722b9o2.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Velingrad - Ostrets peak", 0, 4 },
                    { 2, "The trail from Sveta Petka to Ostrets Peak offers a captivating journey through the scenic beauty of the Rhodope Mountains in Bulgaria. Starting at the quaint village of Sveta Petka, the trail meanders through lush forests, tranquil meadows, and rocky terrain. Along the way, hikers are treated to panoramic views of the surrounding valleys and peaks, providing ample opportunities for photography and contemplation. The trail is well-maintained but can be challenging in parts, with steep ascents and descents. However, the effort is rewarded with the stunning natural landscapes and the sense of accomplishment upon reaching Ostrets Peak. At the summit, adventurers are greeted with breathtaking vistas that stretch as far as the eye can see, making the journey from Sveta Petka an unforgettable outdoor experience.", 0, 5.2000000000000002, new TimeSpan(0, 2, 0, 0, 0), 360, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjZbKuVC8Wp7jV29Wl2FBZABOq87KP5S9W1ot5Q-keCnleh31N3MtM1HottF4hvKvHjnUN8_n8evU_TFEMevjoxPMuIlNDjC_mKbdaPHnMzxJ1Hz4edohwFMoxpXf0Y5eLTx06WADZ0sE0/s1600/22.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Sveta Petka Village - Ostrets peak", 0, 4 },
                    { 3, "The trail from Malyovitsa Hut to Malyovitsa Peak in the Rila Mountains of Bulgaria offers a captivating adventure amidst stunning alpine scenery. Beginning at the cozy Malyovitsa Hut, nestled in a picturesque valley, the trail ascends gradually through dense forests and rocky slopes. Along the way, hikers are treated to breathtaking views of towering peaks and rugged landscapes. The trail is well-marked and relatively moderate in difficulty, making it accessible to hikers of varying skill levels. As the ascent continues, the scenery becomes increasingly dramatic, with jagged cliffs and cascading waterfalls adding to the allure of the surroundings. Finally, upon reaching the summit of Malyovitsa Peak, adventurers are rewarded with panoramic vistas that stretch as far as the eye can see, offering a sense of accomplishment and awe-inspiring beauty. Whether it's the challenge of the hike or the beauty of the natural surroundings, the trail from Malyovitsa Hut to Malyovitsa Peak promises an unforgettable outdoor experience in the heart of the Rila Mountains.", 3, 8.0999999999999996, new TimeSpan(0, 3, 0, 0, 0), 860, "https://tripsjournal.com/wp-content/uploads/2017/09/11-vryh-malyovitsa.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Malyovitsa hut - Malyovitsa peak", 0, 1 },
                    { 4, "The trail from Ivan Vazov Hut to Malyovitsa Peak in Bulgaria's Rila Mountains offers a thrilling journey through diverse landscapes. Starting at the charming Ivan Vazov Hut, nestled amidst lush forests, the trail gradually ascends through alpine meadows and rocky terrain. Hikers are treated to breathtaking views of towering peaks and serene valleys along the way. The trail is well-marked but can be challenging, with steep sections demanding endurance and agility. As the ascent progresses, the scenery becomes increasingly dramatic, with rugged cliffs and cascading streams adding to the allure. Upon reaching the summit of Malyovitsa Peak, adventurers are rewarded with awe-inspiring vistas stretching as far as the eye can see. Whether seeking adventure or tranquility, the trail from Ivan Vazov Hut to Malyovitsa Peak promises an unforgettable outdoor experience amidst the natural splendor of the Rila Mountains.", 3, 10.300000000000001, new TimeSpan(0, 4, 30, 0, 0), 770, "https://tabakoff.eu/wp/wp-content/uploads/2016/09/DSC_0063.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ivan Vazov hut - Malyovitsa peak", 0, 1 },
                    { 5, "The trail from Rila Monastery to Malyovitsa Peak offers a captivating journey through the stunning landscapes of the Rila Mountains in Bulgaria. Beginning at the historic Rila Monastery, a UNESCO World Heritage site, the trail winds through picturesque valleys and dense forests, providing glimpses of cultural and natural heritage along the way. As hikers ascend, the scenery transitions to alpine meadows and rocky slopes, with panoramic views of majestic peaks unfolding before them. The trail is well-marked but challenging, with steep sections demanding endurance and determination. However, the effort is rewarded with breathtaking vistas of the surrounding wilderness and the sense of accomplishment upon reaching Malyovitsa Peak. At the summit, adventurers are greeted with sweeping panoramas that showcase the beauty and grandeur of the Rila Mountains. Whether seeking adventure or spiritual rejuvenation, the trail from Rila Monastery to Malyovitsa Peak promises an unforgettable outdoor experience immersed in the natural splendor of Bulgaria's mountainous landscape.", 4, 12.199999999999999, new TimeSpan(0, 6, 0, 0, 0), 1500, "https://iskamdaletya.com/wp-content/uploads/2018/08/IMG_5475_edited-e1535716578693.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rila Monastery - Malyovitsa peak", 0, 3 },
                    { 6, "The trail from Tevno Ezero Shelter to Kamenitza Peak in Bulgaria's Pirin Mountains offers a captivating journey through pristine alpine scenery. Starting at the tranquil Tevno Ezero Shelter, nestled beside a picturesque lake, the trail leads hikers through dense forests and meandering streams. As the ascent begins, the landscape transforms into rocky terrain, dotted with vibrant alpine flora. The trail is well-marked but challenging, with steep sections demanding endurance and careful footing. Along the way, hikers are rewarded with breathtaking views of jagged peaks and serene valleys, providing ample opportunities for photography and reflection. As the trail nears Kamenitza Peak, the scenery becomes increasingly dramatic, with towering cliffs and rugged ridges dominating the horizon. Upon reaching the summit, adventurers are greeted with panoramic vistas that stretch as far as the eye can see, offering a sense of accomplishment and awe-inspiring beauty. Whether seeking adventure or tranquility, the trail from Tevno Ezero Shelter to Kamenitza Peak promises an unforgettable outdoor experience amidst the natural splendor of the Pirin Mountains.", 3, 6.4000000000000004, new TimeSpan(0, 3, 0, 0, 0), 600, "https://bulgarian-photography.com/UserFiles/pictures/BACEEBE3-8BA4-C931-9AE6-A95F97110DCD.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tevno ezero shelter - Kamenitza peak", 0, 2 },
                    { 7, "The trail from Begovitsa Hut to Kamenitza Peak in Bulgaria's Pirin Mountains is a breathtaking journey through pristine wilderness. Beginning at the charming Begovitsa Hut, nestled amidst lush forests and meadows, the trail gradually ascends through diverse landscapes. Hikers traverse winding paths, crossing crystal-clear streams and ascending rocky slopes. Along the way, the scenery unfolds in a symphony of colors, with vibrant alpine flora lining the trail. The route is well-marked but challenging, with steep sections requiring careful navigation. As hikers ascend, panoramic vistas of towering peaks and deep valleys reward their efforts. Approaching Kamenitza Peak, the landscape becomes increasingly dramatic, with rugged cliffs and rocky outcrops dominating the skyline. At the summit, adventurers are greeted with awe-inspiring views that stretch as far as the eye can see, providing a sense of accomplishment and connection with nature. Whether seeking adventure or tranquility, the trail from Begovitsa Hut to Kamenitza Peak promises an unforgettable outdoor experience amidst the natural splendor of the Pirin Mountains.", 1, 8.0999999999999996, new TimeSpan(0, 3, 30, 0, 0), 1000, "https://qbylkovcvqt.blog.bg/photos/31305/552.JPG", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Begovitsa hut - Kamenitza peak", 0, 2 },
                    { 8, "The trail from Bezbog Hut to Kamenitza Peak in Bulgaria's Pirin Mountains offers an exhilarating adventure through stunning alpine landscapes. Beginning at Bezbog Hut, nestled amid picturesque meadows and forests, the trail ascends gradually, revealing panoramic vistas of rugged peaks and deep valleys. Hikers traverse diverse terrain, from lush forests to rocky slopes, with occasional glimpses of pristine alpine lakes. The well-marked trail presents moderate challenges, with some steep sections requiring careful footing. Along the way, hikers are rewarded with sightings of diverse flora and fauna, adding to the allure of the journey. As the ascent progresses, the scenery becomes increasingly dramatic, with towering cliffs and jagged ridges dominating the horizon. Approaching Kamenitza Peak, the trail offers breathtaking views of the surrounding wilderness, culminating in a sense of accomplishment upon reaching the summit. At the peak, adventurers are treated to awe-inspiring vistas that stretch as far as the eye can see, providing a memorable conclusion to the outdoor experience. Whether seeking adventure or tranquility, the trail from Bezbog Hut to Kamenitza Peak promises an unforgettable journey through the natural splendor of the Pirin Mountains.", 3, 10.6, new TimeSpan(0, 5, 30, 0, 0), 930, "https://kostadinnikolov.com/wp-content/uploads/2020/10/IMG_20200829_111234.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Bezbog hut - Kamenitza peak", 0, 2 },
                    { 9, "The trail from Aleko Hut to Cherni Vrah Peak in Bulgaria's Vitosha Mountain offers a thrilling adventure through diverse landscapes. Starting at Aleko Hut, nestled amidst lush forests and meadows, the trail ascends steadily, providing stunning views of the surrounding valleys and peaks. Hikers navigate well-marked paths, passing through rocky terrain and alpine meadows adorned with colorful wildflowers. The trail presents moderate challenges, with occasional steep sections requiring careful footing. Along the way, hikers encounter unique flora and fauna, adding to the charm of the journey. As the ascent progresses, the scenery becomes increasingly dramatic, with rocky outcrops and rugged cliffs dominating the landscape. Approaching Cherni Vrah Peak, the trail offers breathtaking panoramas of the surrounding wilderness, culminating in a sense of accomplishment upon reaching the summit. At the peak, adventurers are rewarded with awe-inspiring vistas that stretch as far as the eye can see, providing a memorable conclusion to the outdoor experience. Whether seeking adventure or tranquility, the trail from Aleko Hut to Cherni Vrah Peak promises an unforgettable journey through the natural beauty of Vitosha Mountain.", 0, 2.8999999999999999, new TimeSpan(0, 1, 30, 0, 0), 480, "https://tripsjournal.com/wp-content/uploads/2016/03/cherni-vrah.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Aleko hut - Cherni vrah peak", 0, 1 },
                    { 10, "The trail from Zheleznitsa to Cherni Vrah Peak in Bulgaria's Vitosha Mountain offers an exhilarating hike through diverse landscapes. Beginning in the charming village of Zheleznitsa, the trail winds through lush forests and meadows, gradually ascending towards the summit. Hikers traverse well-marked paths, encountering rocky terrain and alpine flora along the way. The trail presents moderate challenges, with some steep sections demanding careful navigation. As the ascent continues, the scenery becomes increasingly dramatic, with panoramic views of the surrounding valleys and peaks unfolding before hikers' eyes. Approaching Cherni Vrah Peak, the trail offers breathtaking vistas of the rugged landscape, culminating in a sense of achievement upon reaching the summit. At the peak, adventurers are treated to sweeping panoramas that stretch as far as the eye can see, providing a memorable conclusion to the hike. Whether seeking adventure or tranquility, the trail from Zheleznitsa to Cherni Vrah Peak promises an unforgettable outdoor experience immersed in the natural beauty of Vitosha Mountain.", 3, 9.9000000000000004, new TimeSpan(0, 4, 30, 0, 0), 1320, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiB8-MfRFKr_g1aXDIFhZWC16NwDeeETLTmq3tVFua_qUCUnaRR0J4I-SN2AM9eLl6rdmXNgVQ30Zu1jix7zRIbmjpyFsWyQhBKnxMzM0QwgHo8MG2xeQ4AilpPUMVbNrH3r0Vr-4wZaVc/s1600/1.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Zheleznitsa - Cherni vrah peak", 0, 1 },
                    { 11, "The trail from Zlatnite Mostove (The Golden Bridges) to Cherni Vrah Peak in Bulgaria's Vitosha Mountain is a breathtaking journey through rugged terrain and stunning vistas. Beginning at the iconic Golden Bridges, where massive rock formations span a mountain river, the trail winds through lush forests and rocky slopes. Hikers traverse well-marked paths, encountering diverse flora and fauna along the way. The trail presents moderate challenges, with occasional steep sections demanding careful footing. As the ascent progresses, the scenery becomes increasingly dramatic, with panoramic views of the surrounding valleys and peaks unfolding before hikers' eyes. Approaching Cherni Vrah Peak, the trail offers awe-inspiring vistas of the rugged landscape, culminating in a sense of achievement upon reaching the summit. At the peak, adventurers are rewarded with sweeping panoramas that stretch as far as the eye can see, providing a memorable conclusion to the hike. Whether seeking adventure or tranquility, the trail from Zlatnite Mostove to Cherni Vrah Peak promises an unforgettable outdoor experience immersed in the natural beauty of Vitosha Mountain.", 1, 6.4000000000000004, new TimeSpan(0, 2, 50, 0, 0), 800, "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/E3_%D0%97%D0%BB%D0%B0%D1%82%D0%BD%D0%B8%D1%82%D0%B5_%D0%BC%D0%BE%D1%81%D1%82%D0%BE%D0%B2%D0%B5.jpg/1280px-E3_%D0%97%D0%BB%D0%B0%D1%82%D0%BD%D0%B8%D1%82%D0%B5_%D0%BC%D0%BE%D1%81%D1%82%D0%BE%D0%B2%D0%B5.jpg", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Zlatnite mostove - Cherni vrah peak", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "TrailsPeaks",
                columns: new[] { "PeakId", "TrailId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0");

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "MountainsRegions",
                keyColumns: new[] { "MountainId", "RegionId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "TrailsPeaks",
                keyColumns: new[] { "PeakId", "TrailId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "Peaks",
                keyColumn: "PeakId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peaks",
                keyColumn: "PeakId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Peaks",
                keyColumn: "PeakId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peaks",
                keyColumn: "PeakId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Mountains",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mountains",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mountains",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mountains",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 4);
        }
    }
}
