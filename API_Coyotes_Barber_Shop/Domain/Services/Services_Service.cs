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


        public async Task<Service> DeteleteServiceAsync(Guid id)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);
                if (service == null)
                {
                    throw new ArgumentException("El Servicio no existe.");
                }
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
                return service;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }




        public async Task<Service> EditServiceAsync(Guid id, decimal nuevoPrecio)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);

                if (service == null)
                {
                    throw new ArgumentException("El Servicio no existe");
                }

                if (!IsDecimal(nuevoPrecio))
                {
                    throw new ArgumentException("El nuevo precio no es un número decimal.");
                }
                if (nuevoPrecio < 10000 || nuevoPrecio > 60000)
                {
                    throw new ArgumentException("El nuevo precio debe estar entre 10,000 y 60,000.");
                }
                service.Precio = nuevoPrecio;
                await _context.SaveChangesAsync();
                return service;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Service> GetServiceById(Guid id)
        {

            try
            {
                var Service = await _context.Services.FindAsync(id);
                if (Service == null)
                {
                    throw new ArgumentException("El Servicio no existe.");
                }
                else
                {
                    return Service;
                }


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

        //method to find out if it is decimal or not

        private bool IsDecimal(decimal value)
        {
            return decimal.TryParse(value.ToString(), out _);
        }
    }
}

