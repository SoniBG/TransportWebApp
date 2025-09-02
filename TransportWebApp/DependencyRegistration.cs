using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using TransportWebApp.Application.Services;
using TransportWebApp.Application.Utilities;
using TransportWebApp.Components.Account;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp;

public static class DependencyRegistration
{
    public static IServiceCollection RegisterSecurity(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCascadingAuthenticationState();

        services
            .AddIdentity<ApplicationUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        return services;
    }

    public static IServiceCollection RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        services.AddTransient<IEmailSender, SmtpEmailSender>();
        services.AddScoped<EmailGenerator>();

        return services;
    }
}
