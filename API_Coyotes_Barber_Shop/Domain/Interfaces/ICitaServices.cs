using API_Coyotes_Barber_Shop.DAL.Entities;

namespace API_Coyotes_Barber_Shop.Domain.Interfaces
{
    public interface ICitaServices
    {
        Task<IEnumerable<Cita>> GetCitaAsync();

        Task<IEnumerable<Cita>> GetCitaByBarberIdAsync(Guid barberId);

        Task<Cita> GetCitaByIdAsync(Guid id);

        Task<Cita> CreateCitaAsync(Cita cita);

        Task<Cita> UpdateCitaAsync(Guid id);

        Task<Cita> DeleteCitaAsync(Guid id);
    }
}
