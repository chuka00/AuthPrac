using AuthPrac.Entities;

namespace AuthPrac.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
    }
}
