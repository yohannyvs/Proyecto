using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Repositorio;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("dbContextConnection") ?? throw new InvalidOperationException("Connection string 'dbContextConnection' not found.");

builder.Services.AddDbContext<dbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<dbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

AddScoped();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapRazorPages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void AddScoped()
{
    builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
    builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
    builder.Services.AddScoped<IUnidadRepositorio, UnidadRepositorio>();
    builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
    builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
}