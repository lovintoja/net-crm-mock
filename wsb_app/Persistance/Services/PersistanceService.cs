using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AppPersistance;
internal class PersistanceService : IPersistanceService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public PersistanceService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task AddRoles()
    {
        var userRole = new IdentityRole { Name = "User" };
        await _roleManager.CreateAsync(userRole);

        var adminRole = new IdentityRole { Name = "Admin" };
        await _roleManager.CreateAsync(adminRole);
    }
}
