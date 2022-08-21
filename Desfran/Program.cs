using Desfran.Models.DBContext;
using Desfran.Services.Interfaces;
using Desfran.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dataSource = Path.Combine(Environment.CurrentDirectory + @"\wwwroot\db\desfran.db");

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<DesfranContext>(options => options.UseSqlite($"Data Source={dataSource};"));
builder.Services.AddScoped<IAccountInterface, AccountRepository>();
builder.Services.AddScoped<IWeatherInterface, WeatherRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
