namespace MountainTrailsSystem.Infrastructure.Constants
{
    public static class MessageConstants
    {
        public const string RequiredErrorMessage = "The field {0} is required";

        public const string FieldLengthErrorMessage = "The field {0} should be between {2} and {1} characters long";

        public const string DurationLengthErrorMessage = "The {0} should be between {2} and {1} hours";

        public const string PeakElevationErrorMessage = "The {0} of the peak should be between {1} and {2} meters";

        public const string TrailDurationErrorMessage = "The {0} of the trail should be between {1} km and {2} km";

        public const string TrailElevationErrorMessage = "The elevation gained of the trail should be between {1} and {2} meters";

        public const string DurationHoursErrorMessage = "The hours should be between {1} and {2}";

        public const string DurationMinutesErrorMessage = "The minutes should be between {1} and {2}";
    }
}
