using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using ConsoleApp.Services;

public class CustomerService(CustomerRepository customerRepository, AddressService addressService, IdentityService identityService)
{
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly AddressService _addressService = addressService;
    private readonly IdentityService _identityService = identityService;

    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string identityName, string streetName, string postalCode, string city)
    {
        var identityEntity = _identityService.CreateIdentity(identityName);
        var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);

        var customerEntity = new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IdentityId = identityEntity.Id,
            AddressId = addressEntity.Id
        };

        customerEntity = _customerRepository.Create(customerEntity);

        return customerEntity;
    }


    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == email);
        return customerEntity;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

  
    public IEnumerable<CustomerEntity> GetCustomers()
    {
        var customers = _customerRepository.GetAll();
        return customers;
    }


    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return updatedCustomerEntity;
    }


    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(x => x.Id == id);
    }

}
