namespace MountainTrailsSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        //Mountain
        public const int MountainNameMaximumLength = 50;
        public const int MountainNameMinimumLength = 3;

        //Region
        public const int RegionNameMaximumLength = 30;
        public const int RegionNameMinimumLength = 3;

        //Peak
        public const int PeakNameMaximumLength = 50;
        public const int PeakNameMinimumLength = 3;

        public const int PeakDescriptionMaximumLength = 500;
        public const int PeakDescriptionMinimumLength = 50;

        public const int PeakMaximumElevation = 8848;
        public const int PeakMinimumElevation = 1;

        //Trail
        public const int TrailNameMaximumLength = 100;
        public const int TrailNameMinimumLength = 10;

        public const int TrailDescriptionMaximumLength = 2000;
        public const int TrailDescriptionMinimumLength = 100;

        public const int TrailMinimumElevationGain = 1;

        public const double TrailMinimumDistance = 0.5;

        public const int TrailRatingMaximumValue = 5;
        public const int TrailRatingMinimumValue = 1;

        public const string TrailMaximumDuration = "72:00:00";
        public const string TrailMinimumDuration = "00:30:00";

        //TrailStatusNote
        public const int TrailStatusNoteMaximumLength = 500;
        public const int TrailStatusNoteMinimumLength = 50;
    }
}
