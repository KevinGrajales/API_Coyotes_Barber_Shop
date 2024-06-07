using API_Coyotes_Barber_Shop.DAL;
using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Coyotes_Barber_Shop.Domain.Services
{
    public class BarberService : IBarberServices
    {
        private readonly DataBaseContext _context;

        public BarberService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Barber> CreateBarberAsync(Barber barber)
        {
            try
            {

                barber.Id = Guid.NewGuid();
                _context.Barbers.Add(barber);

                await _context.SaveChangesAsync();
                return barber;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Barber> DeleteBarberAsync(Guid id)
        {
            try
            {
                var barber = await _context.Barbers.FindAsync(id);
                if (barber == null)
                {
                    throw new ArgumentException("El barbero no existe.");
                }
                _context.Barbers.Remove(barber);
                await _context.SaveChangesAsync();
                return barber;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }

        }

        public async Task<Barber> EditBarberAsync(Guid id, string email, string celphone)
        {
            try
            {
                var barber = await _context.Barbers.FindAsync(id);
                if (barber == null)
                {
                    throw new ArgumentException("El barbero no existe.");
                }

                if (!string.IsNullOrWhiteSpace(email))
                {
                    barber.Email = email;
                }

                if (!string.IsNullOrWhiteSpace(celphone) && celphone.Length == 10 && celphone.All(char.IsDigit))
                {
                    barber.CelPhone = celphone;
                }

                await _context.SaveChangesAsync();
                return barber;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Barber> GetBarberById(Guid id)
        {

            try
            {

                // get a object until the DB.
                var Barber = await _context.Barbers.FindAsync(id);
                if (Barber == null)
                {
                    throw new ArgumentException("El Barbero no existe.");
                }

                return Barber;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<IEnumerable<Barber>> GetBarbersAsync()
        {

            try
            {
                var Barbers = await _context.Barbers.ToListAsync();

                return Barbers;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }
    }
}
