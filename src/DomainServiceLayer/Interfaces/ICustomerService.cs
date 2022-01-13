using DomainLayer.Model;

namespace DomainServiceLayer.Interfaces;

public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomers();
    Customer GetCustomer(int id);
    void InsertCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
}