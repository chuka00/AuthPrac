using AuthPrac.Entities;

namespace AuthPrac.Interfaces
{
    public interface IVendorServices
    {
        Task<Product> GetProduct(int id);
        ICollection<Product> GetAllProducts();
    }
}
