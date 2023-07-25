
using KabulCrypto.Crypto.GrpcService.Services;

namespace KabulCrypto.Crypto.GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterServices(builder.Configuration);

            var app = builder.Build();

            app.UseCors("corsapp");

            app.UseGrpcWeb();

            app.MapGrpcService<WalletService>().EnableGrpcWeb();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}