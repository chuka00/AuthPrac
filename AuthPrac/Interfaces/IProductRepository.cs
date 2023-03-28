using AuthPrac.Dto;
using AuthPrac.Entities;

namespace AuthPrac.Interfaces
{
    public interface IProductRepository
    {
        Task<string>  CreateProduct(ProductDto product);
        bool DeleteProduct(Product product);

        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        bool ProductExist(int prodId);
        bool Save();
    }
}
