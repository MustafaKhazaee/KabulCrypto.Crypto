
using KabulCrypto.Crypto.Domain.Common;

namespace KabulCrypto.Crypto.Domain.Entities;

public class Wallet : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
