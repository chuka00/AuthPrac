using AuthPrac.Data;
using AuthPrac.Entities;
using AuthPrac.Interfaces;

namespace AuthPrac.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<Product> GetProducts()
        {
            return _appDbContext.Products.OrderBy(p => p.ProductId).ToList();
        }
    }
}
