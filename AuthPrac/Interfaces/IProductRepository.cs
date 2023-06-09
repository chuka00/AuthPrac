﻿using AuthPrac.Entities;

namespace AuthPrac.Interfaces
{
    public interface IProductRepository
    {
        bool DeleteProduct(Product product);

        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        bool ProductExist(int prodId);
        bool Save();
    }
}
