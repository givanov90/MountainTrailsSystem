using System.ComponentModel.DataAnnotations;

namespace MountainTrailsSystem.Infrastructure.Attributes
{
    public class DurationRangeAttribute : ValidationAttribute
    {
        private readonly TimeSpan minDuration;
        private readonly TimeSpan maxDuration;

        public DurationRangeAttribute(string _minDuration, string _maxDuration)
        {
            minDuration = TimeSpan.Parse(_minDuration);
            maxDuration = TimeSpan.Parse(_maxDuration);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is TimeSpan duration)
            {
                if (duration < minDuration || duration > maxDuration)
                {
                    return new ValidationResult($"The duration must be between {minDuration} and {maxDuration}.");
                }
            }
            else
            {
                return new ValidationResult("The duration field should be in format 'hh:mm:ss'");
            }

            return ValidationResult.Success;
        }
    }
}
