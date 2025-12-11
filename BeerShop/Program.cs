using BeerShop.Domains.DataDB;
using BeerShop.Domains.EntitiesDB;
using BeerShop.Repositories;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services;
using BeerShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<BeerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IBeerDAO, BeerDAO>();

builder.Services.AddScoped<IService<Brewery>, BreweryService>();
builder.Services.AddScoped<IDAO<Brewery>, BreweryDAO>();

builder.Services.AddScoped<IService<Variety>, VarietyService>();
builder.Services.AddScoped<IDAO<Variety>, VarietyDAO>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
