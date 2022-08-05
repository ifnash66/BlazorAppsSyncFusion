using System.Security.Claims;
using BlazorServer.Constants;

namespace BlazorServer.Data;

public class SeedUsersAndRoles
{
    public static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync(ApplicationRoles.Admin).Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = ApplicationRoles.Admin
            };
            
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }

        if (!roleManager.RoleExistsAsync(ApplicationRoles.CaseWorker).Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = ApplicationRoles.CaseWorker
            };
            
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }
        
        if (!roleManager.RoleExistsAsync(ApplicationRoles.ReadOnly).Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = ApplicationRoles.ReadOnly
            };
            
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }
    }
    
    public static void SeedUsers(UserManager<IdentityUser> userManager)
    {
        if (userManager.FindByNameAsync("inash@live.co.uk").Result == null)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "inash@live.co.uk",
                Email = "inash@live.co.uk"
            };

            IdentityResult result = userManager.CreateAsync(user, "Void1966@@").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, ApplicationRoles.Admin).Wait();
            }
        }
    }
}