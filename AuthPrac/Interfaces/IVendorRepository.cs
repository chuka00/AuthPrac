using AuthPrac.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthPrac.Interfaces
{
    public interface IVendorRepository
    {
        bool DeleteProduct(Product product);

        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        bool ProductExist(int prodId);
        bool Save();
    }
}
