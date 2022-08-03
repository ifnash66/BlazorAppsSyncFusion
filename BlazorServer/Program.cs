using AutoMapper;
using BlazorServer.Data.Contexts;
using BlazorServer.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new HostMappingProfile());
    mc.AddProfile(new GuestMappingProfile());
    mc.AddProfile(new HomeVisitMappingProfile());
    mc.AddProfile(new CaseRecordMappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Njg2OTgxQDMyMzAyZTMyMmUzMGhFYkU0bEZsNWQ0VGxDdTA5dERsdkhmTHRsSldtdmtGbTJRYUl6MlU3Y1U9");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();