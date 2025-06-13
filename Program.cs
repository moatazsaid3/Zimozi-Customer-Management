using CustomerManagement;
using CustomerManagement.Filters;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Encodings.Web;

// Create the WebApplication builder
var builder = WebApplication.CreateBuilder(args);

// Add MVC and JSON config
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<BasicAuthFilter>(); // Apply authentication filter globally
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Add EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Kendo UI
builder.Services.AddKendo();

// Add session support
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add dependency injection for auth services
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<BasicAuthFilter>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session
app.UseSession();

// Enable authorization
app.UseAuthorization();

// Default routing
app.MapDefaultControllerRoute();

app.Run();
