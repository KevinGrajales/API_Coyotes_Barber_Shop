using API_Coyotes_Barber_Shop.DAL.Entities;

namespace API_Coyotes_Barber_Shop.Domain.Interfaces
{
    public interface IService_Services
    {
        Task<IEnumerable<Service>> GetServicesAsync(); // this is a signature of a method

        Task<Service> CreateServiceAsync(Service service);

        Task<Service> GetServiceById(Guid id);

        Task<Service> EditServiceAsync(Guid id, decimal nuevoPrecio);

        Task<Service> DeteleteServiceAsync(Guid id);



    }
}


