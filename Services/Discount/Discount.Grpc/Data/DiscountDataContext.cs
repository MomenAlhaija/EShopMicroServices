using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountDataContext:DbContext
{
    public DiscountDataContext(DbContextOptions<DiscountDataContext> options):base(options)
    {
            
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(

            new Coupon { Id=1,ProductName="IPhone X",Description="IPhone Discount",Amount=50},

               new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung 10 Discount", Amount = 30 }
        );
    }
    public DbSet<Coupon> coupons { get; set; } = default!;
    

}
