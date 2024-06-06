using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.DAL;
using Microsoft.EntityFrameworkCore;
using API_Coyotes_Barber_Shop.Domain.Interfaces;

namespace API_Coyotes_Barber_Shop.Domain.Services
{
    public class Services_Service : IService_Services
    {
        private readonly DataBaseContext _context;

        public Services_Service(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            try
            {

                service.Id = Guid.NewGuid();
                _context.Services.Add(service);

                await _context.SaveChangesAsync();
                return service;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }


        public Task<Service> DeteleteServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

      


        public Task<Service> EditServiceAsync(Service barber)
        {
            throw new NotImplementedException();
        }

        public async Task<Service> GetServiceById(Guid id)
        {

            try
            {
                var Service = await _context.Services.FirstOrDefaultAsync(b => b.Id == id);
                // get a object until the DB.
                var Service1 = await _context.Services.FindAsync(id);
                var Service2 = await _context.Services.FirstAsync(b => b.Id == id);

                return Service;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {

            try
            {
                var Services = await _context.Services.ToListAsync();

                return Services;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        
    }
}
