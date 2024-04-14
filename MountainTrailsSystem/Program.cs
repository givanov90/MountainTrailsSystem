using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddScoped<ITrailService, TrailService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IMountainService, MountainService>();
builder.Services.AddScoped<IPeakService, PeakService>();
builder.Services.AddScoped<IStatusNoteService, StatusNoteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
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
        name: "Trail Details",
        pattern: "/Trail/Details/{id}/{information}",
        defaults: new { Controller = "Trail", Action = "Details" }
    );

    endpoints.MapControllerRoute(
    name: "Peak Details",
    pattern: "/Peak/Details/{id}/{information}",
    defaults: new { Controller = "Peak", Action = "Details" }
);

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.CreateAdministratorRoleAsync();

app.Run();
