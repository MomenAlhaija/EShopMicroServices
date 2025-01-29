

namespace Order.Infrastructure;

public static class DependencyInfrastructureInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost;Database=OrderDataBase;User Id=Momen;Password=Momen1999;Encrypt=False;TrustServerCertificate=True;"));
        return services;
    }   
}
