using System.Security.Claims;
using BlazorServer.Constants;

namespace BlazorServer.Data;

public static class SeedUsersAndRoles
{
    public static void SeedData(AppDbContext dbContext)
    {
        var visitStatusList = dbContext.VisitStatuses.ToList();
        if (!visitStatusList.Any())
        {
            dbContext.VisitStatuses.Add(new VisitStatus
                {Title = "Scheduled", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.VisitStatuses.Add(new VisitStatus
                {Title = "Complete", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.VisitStatuses.Add(new VisitStatus
                {Title = "In Progress", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.SaveChanges();
        }

        var caseNoteCategories = dbContext.CaseNoteCategories.ToList();
        if (!caseNoteCategories.Any())
        {
            dbContext.CaseNoteCategories.Add(new CaseNoteCategory
                {Title = "General", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.CaseNoteCategories.Add(new CaseNoteCategory
                {Title = "Safeguarding", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.CaseNoteCategories.Add(new CaseNoteCategory
                {Title = "Housing", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.CaseNoteCategories.Add(new CaseNoteCategory
                {Title = "Finances", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.SaveChanges();
        }

        var genders = dbContext.Genders.ToList();
        if (!genders.Any())
        {
            dbContext.Genders.Add(new Gender {Title = "Male", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.Genders.Add(new Gender {Title = "Female", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.Genders.Add(new Gender {Title = "Other", DateCreated = DateTime.Now, CreatedBy = "System"});
            dbContext.SaveChanges();
        }
    }

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

    public static void SeedUsers(UserManager<AppUser> userManager)
    {
        if (userManager.FindByNameAsync("inash@live.co.uk").Result == null)
        {
            AppUser user = new AppUser
            {
                FirstName = "Ian",
                LastName = "Nash",
                IsValid = true,
                UserName = "inash@live.co.uk",
                Email = "inash@live.co.uk",
                EmailConfirmed = true
            };

            IdentityResult result = userManager.CreateAsync(user, "Void1966@@").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, ApplicationConstants.Admin).Wait();
                IdentityResult fullNameResult = userManager
                    .AddClaimAsync(user, new Claim(ApplicationConstants.FullNameClaim, $"{user.FirstName} {user.LastName}")).Result;
                
                IdentityResult isValidResult = userManager
                    .AddClaimAsync(user, new Claim(ApplicationConstants.IsValid, user.IsValid.ToString())).Result;
            }
        }
    }
}