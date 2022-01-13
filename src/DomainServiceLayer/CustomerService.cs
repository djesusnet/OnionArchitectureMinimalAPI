using DomainLayer.Model;
using DomainServiceLayer.Interfaces;
using InfrastructureLayer.Repositories.Interfaces;

namespace DomainServiceLayer;

public class CustomerService : ICustomerService
{
    private readonly IBaseRepository<Customer> _repository;

    public CustomerService(IBaseRepository<Customer> repository)
    {
        _repository = repository;
    }

    public void DeleteCustomer(int id)
    {
        var customer = GetCustomer(id);
        _repository.Remove(customer);
        _repository.SaveChanges();
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _repository.GetAll();
    }

    public Customer GetCustomer(int id)
    {
        return _repository.GetById(id);
    }

    public void InsertCustomer(Customer customer)
    {
        _repository.Insert(customer);
    }

    public void UpdateCustomer(Customer customer)
    {
        _repository.Update(customer);
    }
}