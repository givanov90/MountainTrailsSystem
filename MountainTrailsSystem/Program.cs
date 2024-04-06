using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Services;
using MountainTrailsSystem.Infrastructure.Data;
using MountainTrailsSystem.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MountainTrailsSystemDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MountainTrailsSystemDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITrailService, TrailService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.CreateAdministratorRoleAsync();

app.Run();
