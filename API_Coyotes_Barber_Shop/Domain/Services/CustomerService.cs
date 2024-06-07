using API_Coyotes_Barber_Shop.DAL;
using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Coyotes_Barber_Shop.Domain.Services
{
    public class CustomerService : ICustomerServices    
    {
        private readonly DataBaseContext _context;

        public CustomerService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            try
            {

               customer.Id = Guid.NewGuid();
                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();
                return customer;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Customer> DeleteCustomerAsync(Guid id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    throw new ArgumentException("El Cliente no existe.");
                }
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Customer> EditCustomerAsync(Guid id, string email, string celphone)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    throw new ArgumentException("El Cliente no existe.");
                }

                if (!string.IsNullOrWhiteSpace(email))
                {
                    customer.Email = email;
                }

                if (!string.IsNullOrWhiteSpace(celphone) && celphone.Length == 10 && celphone.All(char.IsDigit))
                {
                    customer.CelPhone = celphone;
                }

                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {

            try
            {

                var Customer = await _context.Customers.FindAsync(id);


                if(Customer == null)
                {
                    throw new ArgumentException("El Cliente no existe.");
                }

                return Customer;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {

            try
            {
                var Customers = await _context.Customers.ToListAsync();

                return Customers;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

    }
}
