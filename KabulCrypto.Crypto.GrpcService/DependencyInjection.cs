
using KabulCrypto.Crypto.Application;
using KabulCrypto.Crypto.Infrastructure;

namespace KabulCrypto.Crypto.GrpcService;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpc();

        services.AddApplication(configuration);
        
        services.AddInfrastructure(configuration);

        var frontendUrl = configuration.GetValue<string>("FrontendURL");

        services.AddCors(p => p.AddPolicy("corsapp", builder =>
            builder
            .WithOrigins(frontendUrl!)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        ));
    }
}
