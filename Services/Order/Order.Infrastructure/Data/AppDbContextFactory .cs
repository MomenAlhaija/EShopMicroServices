using Microsoft.EntityFrameworkCore.Design;

namespace Order.Infrastructure.Data;

internal class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=OrderDataBase;User Id=Momen;Password=Momen1999;Encrypt=False;TrustServerCertificate=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
