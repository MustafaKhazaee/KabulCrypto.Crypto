
using Grpc.Core;
using KabulCrypto.Crypto.Application.Queries;
using MediatR;

namespace KabulCrypto.Crypto.GrpcService.Services;

public class WalletService : Wallet.WalletBase
{
    private readonly IMediator _mediator;

    public WalletService(IMediator sender)
    {
        _mediator = sender;
    }

    public async override Task<GetWalletsResponse> GetWallets(GetWalletsRequest request, ServerCallContext context)
    {
        var wallets = await _mediator.Send(new GetWalletQuery());

        var response = new GetWalletsResponse();

        response.Wallets.AddRange(wallets);

        return response;
    }
}
