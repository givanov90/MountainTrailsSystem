using MountainTrailsSystem.Core.Models.Mountain;

namespace MountainTrailsSystem.Core.Contracts
{
    public interface IMountainService
    {
        Task<IEnumerable<MountainServiceModel>> AllMountainsAsync();

        Task CreateMountainAsync(CreateMountainFormModel model);

        Task<bool> MountainExistsAsync(string mountainName);
    }
}
