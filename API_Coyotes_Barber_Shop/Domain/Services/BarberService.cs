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

        public Task<Barber> DeteleteBarberAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Barber> EditBarberAsync(Barber barber)
        {
            throw new NotImplementedException();
        }

        public async Task<Barber> GetBarberById(Guid id)
        {

            try
            {
                var Barber = await _context.Barbers.FirstOrDefaultAsync(b => b.Id == id);
            // get a object until the DB.
            var Barber1 = await _context.Barbers.FindAsync(id);
            var Barber2 = await _context.Barbers.FirstAsync(b => b.Id == id);

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
