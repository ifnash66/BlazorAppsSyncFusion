using System.Security.Claims;
using BlazorServer.Constants;

namespace BlazorServer.Data;

public static class SeedUsersAndRoles
{
    public static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync(ApplicationConstants.Admin).Result)
        {
            IdentityRole adminRole = new IdentityRole
            {
                Name = ApplicationConstants.Admin
            };

            IdentityResult roleResult = roleManager.CreateAsync(adminRole).Result;
            if (roleResult.Succeeded)
            {
                // Add role claims here.
                var adminPermissions = ApplicationPermissions.GetAdminPermissions();
                foreach (var permission in adminPermissions)
                {
                    IdentityResult addPermissionResult = roleManager.AddClaimAsync(adminRole,
                        new Claim(ApplicationConstants.PermissionClaim, permission)).Result;
                }
            }
        }

        if (!roleManager.RoleExistsAsync(ApplicationConstants.CaseWorker).Result)
        {
            IdentityRole caseWorkerRole = new IdentityRole
            {
                Name = ApplicationConstants.CaseWorker
            };

            IdentityResult roleResult = roleManager.CreateAsync(caseWorkerRole).Result;
            if (roleResult.Succeeded)
            {
                // Add role claims here.
                var caseWorkerPermissions = ApplicationPermissions.GetCaseWorkerPermissions();
                foreach (var permission in caseWorkerPermissions)
                {
                    IdentityResult addPermissionResult = roleManager.AddClaimAsync(caseWorkerRole,
                        new Claim(ApplicationConstants.PermissionClaim, permission)).Result;
                }
            }
        }

        if (!roleManager.RoleExistsAsync(ApplicationConstants.ReadOnly).Result)
        {
            IdentityRole readOnlyRole = new IdentityRole
            {
                Name = ApplicationConstants.ReadOnly
            };

            IdentityResult roleResult = roleManager.CreateAsync(readOnlyRole).Result;
            if (roleResult.Succeeded)
            {
                // Add role claims here.
                var readOnlyPermissions = ApplicationPermissions.GetReadOnlyPermissions();
                foreach (var permission in readOnlyPermissions)
                {
                    IdentityResult addPermissionResult = roleManager.AddClaimAsync(readOnlyRole,
                        new Claim(ApplicationConstants.PermissionClaim, permission)).Result;
                }
            }
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
                userManager.AddToRoleAsync(user, ApplicationConstants.Admin).Wait();
                
                IdentityResult fullNameResult = userManager
                    .AddClaimAsync(user, new Claim(ApplicationConstants.FullNameClaim, "Ian Nash")).Result;
            }
        }
    }
}