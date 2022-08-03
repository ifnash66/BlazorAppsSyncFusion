using AutoMapper;
using BlazorApps.Shared;
using BlazorServer.MappingProfiles;
using BlazorServer.Services;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new HostMappingProfile());
    mc.AddProfile(new GuestMappingProfile());
    mc.AddProfile(new HomeVisitMappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<DataService>();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<HostClientService>(client => client.BaseAddress = new Uri("https://localhost:7099/api/Hosts/"));
builder.Services.AddHttpClient<GuestClientService>(client => client.BaseAddress = new Uri("https://localhost:7099/api/Guests/"));
builder.Services.AddHttpClient<HomeVisitClientService>(client => client.BaseAddress = new Uri("https://localhost:7099/api/HomeVisits/"));

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Njg2OTgxQDMyMzAyZTMyMmUzMGhFYkU0bEZsNWQ0VGxDdTA5dERsdkhmTHRsSldtdmtGbTJRYUl6MlU3Y1U9");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseExceptionHandler("/Error");
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();