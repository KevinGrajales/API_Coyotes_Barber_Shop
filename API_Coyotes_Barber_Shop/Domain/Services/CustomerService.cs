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

        public Task<Barber> EditCustomerAsync(Guid id, string email, string celphone)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {

            try
            {
                var Customer = await _context.Customers.FirstOrDefaultAsync(b => b.Id == id);
                // get a object until the DB.
                var Customer1 = await _context.Customers.FindAsync(id);
                var Customer2 = await _context.Customers.FirstAsync(b => b.Id == id);

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
