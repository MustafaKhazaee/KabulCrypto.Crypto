using KabulCrypto.Crypto.Domain.Interfaces;
using KabulCrypto.Crypto.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KabulCrypto.Crypto.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CryptoDb");

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => 
            {
                options.UseNpgsql( connectionString );
                options.EnableDetailedErrors();
            }, 

            ServiceLifetime.Scoped        
        );
    }
}
