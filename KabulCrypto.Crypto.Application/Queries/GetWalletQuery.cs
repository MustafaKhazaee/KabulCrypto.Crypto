using MediatR;
using KabulCrypto.Crypto.Domain.Interfaces;
using KabulCrypto.Crypto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KabulCrypto.Crypto.Application.Queries
{
    public class GetWalletQuery : IRequest<List<string>>
    {
    }

    public class GetWalletQueryResponse : IRequestHandler<GetWalletQuery, List<string>>
    {
        private readonly IApplicationDbContext _context;

        public GetWalletQueryResponse(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            var walletDbSet = _context.Set<Wallet>();

            var wallets = await walletDbSet.ToListAsync(cancellationToken); 

            return walletDbSet.Select(w => w.Name).ToList();
        }
    }
}
