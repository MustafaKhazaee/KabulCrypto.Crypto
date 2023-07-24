using KabulCrypto.Crypto.Domain.Entities;
using KabulCrypto.Crypto.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KabulCrypto.Crypto.Infrastructure.Persistence
{

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Wallet> Wallets { get; set; }


    }
}