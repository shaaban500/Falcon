using Falcon.Models;
using Falcon.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILeetCodeContests, LeetCodeContests>();
builder.Services.AddScoped<ICodeforcesContests, CodeforcesContests>();

var app = builder.Build();

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
