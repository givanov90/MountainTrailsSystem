using MountainTrailsSystem.Core.Contracts;

namespace MountainTrailsSystem.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetTrailDetails(this ITrailModel model)
        {
            string modifiedName = model.Name.Replace(" -", "");

            string details = modifiedName.Replace(" ", "-");

            return details;
        }

        public static string GetPeakDetails(this IPeakModel model)
        {
            string details = model.Name.Replace(" ", "-") + "-" + model.Mountain.Replace(" ", "-");

            return details;
        }
    }
}
