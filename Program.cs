using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClothesMVC.Data;
using ClothesMVC.Models;
using Auth0.AspNetCore.Authentication;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClothesMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClothesMVCContext") ?? throw new InvalidOperationException("Connection string 'ClothesMVCContext' not found.")));

builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.Scope = "openid profile email";
    });
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clothes}/{action=Login}/{id?}");

app.Run();
