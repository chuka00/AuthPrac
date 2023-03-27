using AuthPrac.Data;
using AuthPrac.Entities;
using AuthPrac.Interfaces;

namespace AuthPrac.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool CustomerExist(int custId)
        {
            return _appDbContext.Customers.Any(c => c.CustomerId == custId);

        }

        public Customer GetCustomer(int id)
        {
            return _appDbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
        }

        public Customer GetCustomer(string name)
        {
            return _appDbContext.Customers.Where(p => p.FullName == name).FirstOrDefault();
        }

        public ICollection<Customer> GetCustomers()
        {
            return _appDbContext.Customers.OrderBy(p => p.CustomerId).ToList();
        }

       
    }
}
