using Microsoft.EntityFrameworkCore;
using Order.Domain.Model;
using System.Reflection;
using System.Security.Cryptography;

namespace Order.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options)
    : base(options)
    {
    }
    public  DbSet<Customer> Customers => Set<Customer>();   
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Domain.Model.Order> Orders => Set<Domain.Model.Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

}
