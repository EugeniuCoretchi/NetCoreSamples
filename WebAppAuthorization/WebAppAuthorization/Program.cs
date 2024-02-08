
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WebAppAuthorization.Models;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("ClaimsStoreDb");

services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Register");
    });

services.AddAuthorization(opts => {
    opts.AddPolicy("OnlyForLocal", policy => {
        policy.RequireClaim(ClaimTypes.Locality, "Moldova", "Paris");
    });
    opts.AddPolicy("OnlyForMicrosoft", policy => {
        policy.RequireClaim("company", "Microsoft");
    });
});

services.AddControllersWithViews();

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
