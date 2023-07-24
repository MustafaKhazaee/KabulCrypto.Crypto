
using Grpc.Core;
using KabulCrypto.Crypto.Application.Queries;
using KabulCrypto.Crypto.Domain.Interfaces;
using MediatR;

namespace KabulCrypto.Crypto.GrpcService.Services;

public class WalletService : Wallet.WalletBase
{
    private readonly IMediator _mediator;
    private readonly IApplicationDbContext  _context;

    public WalletService(IMediator sender, IApplicationDbContext context)
    {
        _mediator = sender;
        _context = context;
    }

    public async override Task<GetWalletsResponse> GetWallets(GetWalletsRequest request, ServerCallContext context)
    {
        var wallets = await _mediator.Send(new GetWalletQuery());

        var response = new GetWalletsResponse();

        response.Wallets.AddRange(wallets);

        return response;
    }
}
