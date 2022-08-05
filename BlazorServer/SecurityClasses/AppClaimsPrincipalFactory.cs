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
        var userClaims = await UserManager.GetClaimsAsync(user);
        var fullNameClaim = userClaims?.FirstOrDefault(x => x.Type == ApplicationConstants.FullNameClaim);
        if (fullNameClaim != null)
        {
            if (!claimsIdentity.HasClaim(x => x.Type == ApplicationConstants.FullNameClaim))
            {
                claimsIdentity.AddClaim(new Claim(ApplicationConstants.FullNameClaim, fullNameClaim.Value));
            }
        }

        // Get roleClaims and add to user.
        if (await RoleManager.RoleExistsAsync(ApplicationConstants.Admin))
        {
            if (await UserManager.IsInRoleAsync(user, ApplicationConstants.Admin))
            {
                var adminRole = await RoleManager.FindByNameAsync(ApplicationConstants.Admin);
                var roleClaims = await RoleManager.GetClaimsAsync(adminRole);
                foreach (var claim in roleClaims)
                {
                    if (!claimsIdentity.HasClaim(x => x.Type == claim.Type && x.Value == claim.Value))
                    {
                        claimsIdentity.AddClaim(claim);
                    }
                }
            }
        }

        if (await RoleManager.RoleExistsAsync(ApplicationConstants.CaseWorker))
        {
            if (await UserManager.IsInRoleAsync(user, ApplicationConstants.CaseWorker))
            {
                var caseWorkerRole = await RoleManager.FindByNameAsync(ApplicationConstants.CaseWorker);
                var roleClaims = await RoleManager.GetClaimsAsync(caseWorkerRole);
                foreach (var claim in roleClaims)
                {
                    if (!claimsIdentity.HasClaim(x => x.Type == claim.Type && x.Value == claim.Value))
                    {
                        claimsIdentity.AddClaim(claim);
                    }
                }
            }
        }

        if (await RoleManager.RoleExistsAsync(ApplicationConstants.ReadOnly))
        {
            if (await UserManager.IsInRoleAsync(user, ApplicationConstants.ReadOnly))
            {
                var readOnlyRole = await RoleManager.FindByNameAsync(ApplicationConstants.ReadOnly);
                var roleClaims = await RoleManager.GetClaimsAsync(readOnlyRole);
                foreach (var claim in roleClaims)
                {
                    if (!claimsIdentity.HasClaim(x => x.Type == claim.Type && x.Value == claim.Value))
                    {
                        claimsIdentity.AddClaim(claim);
                    }
                }
            }
        }

        return claimsIdentity;
    }
}