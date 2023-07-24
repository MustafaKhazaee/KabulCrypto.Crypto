using Microsoft.EntityFrameworkCore;

namespace KabulCrypto.Crypto.Domain.Interfaces;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<T> Set<T>() where T : class;
}
