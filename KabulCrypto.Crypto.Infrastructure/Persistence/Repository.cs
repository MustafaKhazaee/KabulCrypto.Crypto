
using KabulCrypto.Crypto.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KabulCrypto.Crypto.Infrastructure.Persistence;

public class Repository<T> : IRepository<T> where T : class
{
    public IQueryable<T> Queryable { get; set; }
    private DbSet<T> DbSet { get; set; }

    public Repository(IApplicationDbContext applicationDbContext)
    {
        DbSet = applicationDbContext.Set<T>();

        Queryable = DbSet.AsQueryable();
    }
}
