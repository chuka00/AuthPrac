using AuthPrac.Entities;

namespace AuthPrac.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer GetCustomer(string name);
        bool CustomerExist(int custId);
    }
}
