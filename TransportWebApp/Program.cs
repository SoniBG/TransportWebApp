using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportWebApp;
using TransportWebApp.Components;
using TransportWebApp.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

SetupApplication(app);

app.Run();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services
        .RegisterSecurity(builder.Configuration)
        .RegisterPersistence(builder.Configuration.GetConnectionString("DefaultConnection"))
        .RegisterDomainServices();

    builder.Services
        .AddRazorComponents()
        .AddInteractiveServerComponents();

}

static async void SetupApplication(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseAntiforgery();

    app.MapStaticAssets();
    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    // Add additional endpoints required by the Identity /Account Razor components.
    app.MapAdditionalIdentityEndpoints();

    // Seed Roles (+ first Admin user)
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        await SeedRolesAndAdminAsync(roleManager, userManager);
    }
}

static async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
{
    string[] roles = ["Admin", "Customer", "Supplier"];

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // Create a default admin user once
    const string adminEmail = "admin@admin.com";
    const string adminPassword = "Admin123!";

    var admin = await userManager.FindByEmailAsync(adminEmail);
    if (admin == null)
    {
        admin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var createResult = await userManager.CreateAsync(admin, adminPassword);
        if (createResult.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
        else
        {
            throw new Exception(string.Join("; ", createResult.Errors.Select(e => e.Description)));
        }
    }
}