var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services
    .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDefaultIdentity<AppUser>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddClaimsPrincipalFactory<AppClaimsPrincipalFactory>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, AppClaimsPrincipalFactory>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 6;

    // Default SignIn settings.
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // Default User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.Name = "BlazorServerCookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Identity/Account/Login";
    // ReturnUrlParameter requires 
    //using Microsoft.AspNetCore.Authentication.Cookies;
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    
    options.AddPolicy("IsAdmin", policy => policy.RequireRole(ApplicationConstants.Admin));
    options.AddPolicy("IsCaseWorker", policy => policy.RequireRole(ApplicationConstants.CaseWorker));
    options.AddPolicy("IsReadOnlyUser", policy => policy.RequireRole(ApplicationConstants.ReadOnly));
    
    options.AddPolicy("HasCaseInvolvement", policy => policy.Requirements.Add(new HasCaseInvolvementRequirement()));
});

builder.Services.AddTransient<IAuthorizationHandler, HasCaseInvolvementHandler>();

builder.Services.Configure<PasswordHasherOptions>(option =>
{
    option.IterationCount = 310_000;
    option.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

builder.Services.AddTransient<HostRepository>();
builder.Services.AddTransient<GuestRepository>();
builder.Services.AddTransient<CaseRepository>();
builder.Services.AddTransient<VisitRepository>();
builder.Services.AddTransient<CaseInvolvementRepository>();
builder.Services.AddTransient<CaseNoteRepository>();
// For Dapper.
builder.Services.AddTransient<SqlRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedUsersAndRoles.SeedRoles(roleManager);
    SeedUsersAndRoles.SeedUsers(userManager);
    SeedUsersAndRoles.SeedData(dbContext);
}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
    "Njg2OTgxQDMyMzAyZTMyMmUzMGhFYkU0bEZsNWQ0VGxDdTA5dERsdkhmTHRsSldtdmtGbTJRYUl6MlU3Y1U9");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();