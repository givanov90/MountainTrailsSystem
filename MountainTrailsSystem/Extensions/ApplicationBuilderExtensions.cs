using Microsoft.AspNetCore.Identity;
using MountainTrailsSystem.Infrastructure.Data.Models;
using static MountainTrailsSystem.Core.Constants.RoleConstants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdministratorRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && !await roleManager.RoleExistsAsync(AdministratorRole))
            {
                var adminRole = new IdentityRole(AdministratorRole);

                await roleManager.CreateAsync(adminRole);

                var administrator = await userManager.FindByNameAsync(AdministratorName);

                if (administrator != null)
                {
                    await userManager.AddToRoleAsync(administrator, adminRole.Name);
                }
            }
        }
    }
}
