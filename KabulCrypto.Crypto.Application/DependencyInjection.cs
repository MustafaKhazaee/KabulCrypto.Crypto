
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KabulCrypto.Crypto.Application;

public static class DependencyInjection
{
    public static void AddApplication (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
    }
}
