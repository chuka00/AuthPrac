using AuthPrac.Data;
using AuthPrac.Entities;
using AuthPrac.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.DAL.Repository;

namespace AuthPrac.Services
{
    public class VendorServices : IVendorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly DbSet<Vendor> _dbset;
        private readonly IRepository<Product> _vendorRepo; 
        public VendorServices(IUnitOfWork unitOfWork, IMapper mapper,AppDbContext context )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_dbset = context.Set<Vendor>;
            _vendorRepo = _unitOfWork.GetRepository<Product>();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _vendorRepo.GetSingleByAsync(u => u.ProductId == id);
           
           // return vendor;
        }

        public ICollection <Product> GetAllProducts()
        {
            return _vendorRepo.GetAll().ToList();
           // return _appDbContext.Products.OrderBy(p => p.ProductId).ToList();
        }
    }
}
