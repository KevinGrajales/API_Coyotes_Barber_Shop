using API_Coyotes_Barber_Shop.DAL;
using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Coyotes_Barber_Shop.Domain.Services
{
    public class CitaService : ICitaServices
    {
        private readonly DataBaseContext _context;

        public CitaService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Cita> CreateCitaAsync(Guid serviceId, string nameService, Guid customerId, string nameCustomer, Guid barberId, string nameBarber, DateTime date, string time, decimal price, bool payment)
        {
            var idService = await _context.Services.FindAsync(serviceId);
            var idCustomer = await _context.Customers.FindAsync(customerId);
            var idBarber = await _context.Barbers.FindAsync(barberId);


            //
            if (idService == null)
            {
                throw new ArgumentException("El Servicio especificado no existe.");
            }
            else if (idService.Name != nameService)
            {
                throw new ArgumentException("El nombre del Servicio especificado no existe.");
            }
            else if (idService.Precio != price)
            {
                throw new ArgumentException("El precio del servicio es erroneo");
            }

            if (idCustomer == null)
            {
                throw new ArgumentException("El Cliente especificado no existe.");
            }
            else if (idCustomer.Name != nameCustomer)
            {
                throw new ArgumentException("El nombre del Cliente especificado no existe.");
            }

            if (idBarber == null)
            {
                throw new ArgumentException("El Barber especificado no existe.");
            }
            else if (idBarber.Name != nameBarber)
            {
                throw new ArgumentException("El nombre del Barbero especificado no existe.");
            }

            //
            bool isBarberAvailable = await _context.Cita
                        .AnyAsync(a => a.BarberId == barberId &&
                         a.Date == date &&
                         a.Time == time);

            if (!isBarberAvailable)
            {
                var cita = new Cita
                {
                    ServiceId = serviceId,
                    NameService = nameService,
                    CustomerId = customerId,
                    NameCustomer = nameCustomer,
                    BarberId = barberId,
                    NameBarber = nameBarber,
                    Date = date,
                    Time = time,
                    Price = price,
                    Payment = false
                };
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return cita;
            }
            else
            {
                throw new ArgumentException("Barber no disponible en esta fecha y hora");
            }

        }

        public Task<Cita> DeleteCitaAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cita>> GetCitaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cita>> GetCitaByBarberIdAsync(Guid barberId)
        {
            throw new NotImplementedException();
        }
        public async Task<Cita> GetCitaByIdAsync(Guid id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {

                throw new ArgumentException("La cita no existe.");
            }
            else
            {
                return cita;
            }
        }

        public Task<Cita> PayCiteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Cita> UpdateCitaAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
