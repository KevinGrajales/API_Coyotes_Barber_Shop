using Microsoft.AspNetCore.SignalR;
using API_Coyotes_Barber_Shop.DAL.Entities;

namespace API_Coyotes_Barber_Shop.Domain.Interfaces
{
    public interface IBarberServices
    {
        Task<IEnumerable<Barber>> GetBarbersAsync(); // this is a signature of a method

        Task<Barber> CreateBarberAsync(Barber barber);

        Task<Barber>GetBarberById(Guid id);

        Task<Barber> EditBarberAsync(Barber barber);

        Task<Barber> DeteleteBarberAsync(Guid id);





    }
}
