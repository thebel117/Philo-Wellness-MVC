using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Models.AutoMap; // Add if using AutoMapper profiles
using PhiloWellnessMVC.Services; // Add if you have services to register

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext with a connection string
builder.Services.AddDbContext<PhiloWellnessDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper configuration if needed
builder.Services.AddAutoMapper(typeof(YourMapProfile)); // Replace with actual profile type

// Add service registrations if needed
builder.Services.AddScoped<IYourService, YourService>(); // Repeat for each service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
