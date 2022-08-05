using System.Security.Claims;
using BlazorServer.Constants;
using Microsoft.Extensions.Options;

namespace BlazorServer.SecurityClasses;

public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
{
    public AppClaimsPrincipalFactory(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
    {
        ClaimsIdentity claimsIdentity = await base.GenerateClaimsAsync(user);
        // Get roleClaims and add to user.
        if (await UserManager.IsInRoleAsync(user, ApplicationConstants.Admin))
        {
            var adminRole = await RoleManager.FindByNameAsync(ApplicationConstants.Admin);
            var roleClaims = await RoleManager.GetClaimsAsync(adminRole);
            claimsIdentity.AddClaims(roleClaims);
        }
        if (await UserManager.IsInRoleAsync(user, ApplicationConstants.CaseWorker))
        {
            var caseWorkerRole = await RoleManager.FindByNameAsync(ApplicationConstants.CaseWorker);
            var roleClaims = await RoleManager.GetClaimsAsync(caseWorkerRole);
            claimsIdentity.AddClaims(roleClaims);
        }
        if (await UserManager.IsInRoleAsync(user, ApplicationConstants.ReadOnly))
        {
            var readOnlyRole = await RoleManager.FindByNameAsync(ApplicationConstants.ReadOnly);
            var roleClaims = await RoleManager.GetClaimsAsync(readOnlyRole);
            claimsIdentity.AddClaims(roleClaims);
        }

        return claimsIdentity;
    }
}