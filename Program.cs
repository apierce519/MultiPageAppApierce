using Microsoft.EntityFrameworkCore;
using MultiPageAppApierce.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContactContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

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

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

    endpoint.MapAreaControllerRoute(
        name: "area",
        areaName: "Admin",
        pattern: "{controller}/{action}/{id?}");
});

app.Run();
