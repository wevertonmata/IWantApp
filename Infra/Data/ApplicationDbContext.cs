using Microsoft.EntityFrameworkCore;
using IWantApp.Domain.Products;
using Flunt.Notifications;

namespace IWantApp.Infra.Data;

public class ApplicationDBContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Ignore<Notification>();

        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);

        builder.Entity<Category>()
               .Property(c => c.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        config.Properties<string>()
            .HaveMaxLength(100);
    }
}

