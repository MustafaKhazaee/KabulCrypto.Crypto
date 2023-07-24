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
        private readonly IRepository<Wallet> _walletRepository;

        public GetWalletQueryResponse(IRepository<Wallet> walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<List<string>> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            var wallets = await _walletRepository.Queryable.ToListAsync(cancellationToken); 

            return wallets.Select(w => w.Name).ToList();
        }
    }
}
