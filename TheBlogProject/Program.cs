using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheBlogProject.Controllers;
using TheBlogProject.Data;
using TheBlogProject.Models;
using TheBlogProject.Services;
using TheBlogProject.Services.Interfaces;
using TheBlogProject.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<BlogUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

builder.Services.AddScoped<DataService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IBlogEmailSender, EmailService>();
builder.Services.AddScoped<IImageService, BasicImageService>();
builder.Services.AddScoped<ISlugService, BasicSlugService>();
builder.Services.AddScoped<BlogSearchService>();


var app = builder.Build();

DataService dataService = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataService>();
if (dataService != null) await dataService.ManageDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "SlugRoute", pattern: "BlogPosts/{slug?}",defaults: new {controller = "Posts", action = "Details"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
