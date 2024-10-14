using Microsoft.EntityFrameworkCore;
using QFeedMill.Models.Entities;
using QFeedMill.Models.IRepository;
using QFeedMill.Models.IServices;
using QFeedMill.Repository;
using QFeedMill.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlServer<ApplicationDbContext>(dbConnection);

//Repository
builder.Services.AddScoped<IFeedRepository, FeedRepository>();

//Service
builder.Services.AddScoped<IFeedServices, FeedServices>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
