using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using MultiPageAppApierce.Models;

var builder = WebApplication.CreateBuilder(args);


//MUST BE CALLED BEFORE AddControllersWithViews()
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// DB Context
builder.Services.AddDbContext<ContactContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")));

builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentContext")));

builder.Services.AddDbContext<CountryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));



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


//// Add Routing
//builder.Services.AddRouting(options =>
//{
//    options.LowercaseUrls = true;
//    options.AppendTrailingSlash = true;
//});

app.UseRouting();

app.UseAuthorization();

//MUST BE CALLED BEFORE UseEndpoints();
app.UseSession();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoint.MapControllerRoute(
        name: "custom",
        pattern: "{controller}/{action}/cat-{activeCategory}/gam-{activeGame}"
    );

    //endpoint.MapControllerRoute(
    //    name: "student",
    //    pattern: "{controller=Student}/{action}/{id?}"
    //    );

    //endpoint.MapControllerRoute(
    //    name: "country",
    //    pattern: "{controller=Country}/{action=Index}/cat-{activeCategory}/gam-{activeGame}"
    //);

    endpoint.MapAreaControllerRoute(
        name: "area",
        areaName: "Admin",
        pattern: "{controller}/{action}/{id?}");
});

app.Run();
