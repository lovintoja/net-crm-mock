using AppPersistance;
using Microsoft.AspNetCore.Identity;
using wsb_app.Data;

namespace wsb_app;

public static class ProgramServicesExtensions
{
    public static void AddRequiredServices(this IServiceCollection services)
    {
        services.AddScoped<IPersistanceService, PersistanceService>();
        services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        });

        services.AddDbContext<ApplicationDbContext>();
        services.AddDbContext<CrmDbContext>();
    }

    public static void UseRequiredServices(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
