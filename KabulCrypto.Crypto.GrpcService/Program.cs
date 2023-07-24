
using KabulCrypto.Crypto.GrpcService.Services;
using KabulCrypto.Crypto.Application;
using KabulCrypto.Crypto.Infrastructure;

namespace KabulCrypto.Crypto.GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGrpc();

            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);

            var frontendUrl = builder.Configuration.GetValue<string>("FrontendURL");

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder
                    .WithOrigins(frontendUrl!)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            var app = builder.Build();

            app.UseCors("corsapp");

            app.UseGrpcWeb();

            app.MapGrpcService<WalletService>().EnableGrpcWeb();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}