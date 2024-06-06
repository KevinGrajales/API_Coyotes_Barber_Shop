using API_Coyotes_Barber_Shop.DAL.Entities;

namespace API_Coyotes_Barber_Shop.Domain.Interfaces
{
    public interface ICustomerServices
    {

        Task<IEnumerable<Customer>> GetCustomersAsync(); // this is a signature of a method

        Task<Customer> CreateCustomerAsync(Customer customer);

        Task<Customer> GetCustomerById(Guid id);

        Task<Customer> EditCustomerAsync(Customer customer);

        Task<Customer> DeleteCustomerAsync(Guid id);

    }
}
