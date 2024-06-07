using API_Coyotes_Barber_Shop.DAL;
using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;

namespace API_Coyotes_Barber_Shop.Domain.Services
{
    public class CitaService : ICitaServices
    {
        private readonly DataBaseContext _context;

        public CitaService(DataBaseContext context)
        {
            _context = context;
        }

        public Task<Cita> CreateCitaAsync(Cita cita)
        {
            throw new NotImplementedException();
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

        public Task<Cita> GetCitaByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Cita> UpdateCitaAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
