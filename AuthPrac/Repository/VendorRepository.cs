using AuthPrac.Data;
using AuthPrac.Entities;
using AuthPrac.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthPrac.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _appDbContext;

        public VendorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool DeleteProduct(Product product)
        {
            _appDbContext.Remove(product);
            return Save();
        }

        public Product GetProduct(int id)
        {
            return _appDbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _appDbContext.Products.Where(p => p.ProductName == name).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _appDbContext.Products.OrderBy(p => p.ProductId).ToList();
        }

        public bool ProductExist(int prodId)
        {
            return _appDbContext.Products.Any(p => p.ProductId == prodId);
        }

        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
