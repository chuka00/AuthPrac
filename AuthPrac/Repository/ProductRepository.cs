using AuthPrac.Data;
using AuthPrac.Dto;
using AuthPrac.Entities;
using AuthPrac.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthPrac.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<string> CreateProduct(ProductDto product)
        {
            Product newProduct = new Product { ProductName = product.ProductName, Price = product.Price, Description = product.Description, Quantity = product.Quantity, Vendor = product.Vendor, VendorId = product.VendorId };

            var newProductResult = _appDbContext.Products.AddAsync(newProduct);
            _appDbContext.SaveChanges();

            if (newProductResult.IsCompletedSuccessfully)
            {
                return "Success";
            }

            return "Error";
           
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
