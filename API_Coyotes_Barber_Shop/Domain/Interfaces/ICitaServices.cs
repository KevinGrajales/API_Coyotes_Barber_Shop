using API_Coyotes_Barber_Shop.DAL.Entities;

namespace API_Coyotes_Barber_Shop.Domain.Interfaces
{
    public interface ICitaServices
    {
        Task<IEnumerable<Cita>> GetCitaAsync();

        Task<IEnumerable<Cita>> GetCitaByBarberIdAsync(Guid barberId);

        Task<Cita> GetCitaByIdAsync(Guid id);

        Task<Cita> CreateCitaAsync(Guid serviceId, string nameService, Guid customerId, string nameCustomer, Guid barberId, string nameBarber, DateTime date, string time, decimal price, bool payment);

        Task<Cita> UpdateCitaAsync(Guid id, string nameService, Guid customerId, string nameCustomer, Guid barberId, string nameBarber, DateTime date, string time, decimal price, bool payment););

        Task<Cita> DeleteCitaAsync(Guid id);

        Task<Cita> PayCiteAsync(Guid id);
    }
}
