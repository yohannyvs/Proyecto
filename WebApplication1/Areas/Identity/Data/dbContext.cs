using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Areas.Identity.Data;

public class dbContext : IdentityDbContext<Usuario>
{
    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Solicitudes> Solicitudes { get; set; }
    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Categoria>().ToTable(nameof(Categorias));
        builder.Entity<Solicitudes>().ToTable(nameof(Solicitudes));
        builder.Entity<Solicitudes>().ToTable(nameof(Solicitudes));
    }
}
