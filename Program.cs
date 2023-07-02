using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NIC.Data;
using NIC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DhsMagacoursesContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DhsMagacoursesContext>();

//Password Complexity
//builder.Services.Configure<IdentityOptions>(
//    options =>
//    {
//        options.Password.RequiredLength = 10;
//        options.Password.RequiredUniqueChars = 3;

//    }
//);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
