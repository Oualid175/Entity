using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Entity.Data;
using Entity.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EntityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'EntityDbContextConnection' not found.");

builder.Services.AddDbContext<EntityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<EntityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<EntityDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
