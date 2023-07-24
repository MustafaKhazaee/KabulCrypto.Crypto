
namespace KabulCrypto.Crypto.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> Queryable { get; set; }
    }
}
