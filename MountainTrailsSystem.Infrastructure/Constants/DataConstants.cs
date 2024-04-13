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

        public const int TrailMaximumElevationGain = 10000;
        public const int TrailMinimumElevationGain = 1;

        public const double TrailMinimumDistance = 0.5;
        public const double TrailMaximumDistance = 5000;

        public const int TrailRatingMaximumValue = 5;
        public const int TrailRatingMinimumValue = 1;

        public const string TrailMaximumDuration = "23:59:59";
        public const string TrailMinimumDuration = "01:00:00";

        public const int TrailDurationMaximumHours = 23;
        public const int TrailDurationMinimumHours = 1;
        public const int TrailDurationMaximumMinutes = 59;
        public const int TrailDurationMinimumMinutes = 0;

        public const double TrailMaximumDurationAsDouble = 24.0;
        public const double TrailMinimumDurationAsDouble = 1.0;

        //TrailStatusNote
        public const int TrailStatusNoteMaximumLength = 500;
        public const int TrailStatusNoteMinimumLength = 50;

        public const int TrailStatusNoteTitleMaximumLength = 60;
        public const int TrailStatusNoteTitleMinimumLength = 7;

        //Peak search condition
        public const int PeakSearchConditionMinimumLength = 3;
        public const int PeakSearchConditionMaximumLength = 50;
    }
}
