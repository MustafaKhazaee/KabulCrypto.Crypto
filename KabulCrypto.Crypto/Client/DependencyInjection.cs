using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace KabulCrypto.Crypto.Client
{
    public static class DependencyInjection
    {
        public static void AddClient (this IServiceCollection services, IConfiguration configuration)
        {
            var backendUrl = configuration.GetValue<string>("BackendURL");

            var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());

            var channel = GrpcChannel.ForAddress(backendUrl!, new GrpcChannelOptions 
            {
                HttpHandler = httpHandler
            });

            // Add all GRPC Clients Here and Inject into Razor Pages :
            services.AddSingleton(s => new Protos.Wallet.WalletClient(channel));

        }
    }
}
