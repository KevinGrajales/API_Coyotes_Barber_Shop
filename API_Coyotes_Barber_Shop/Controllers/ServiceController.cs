using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API_Coyotes_Barber_Shop.DAL.Entities;
using System.Diagnostics.Metrics;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using API_Coyotes_Barber_Shop.Domain.Services;

namespace API_Coyotes_Barber_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IService_Services _service_Services;

        public ServiceController(IService_Services service_Services)
        {
            _service_Services = service_Services;
        }

        [HttpPost, ActionName("CreateService")]
        [Route("Create")]
        public async Task<ActionResult<Service>> CreateServiceAsync(Service service)
        {
            try
            {
                var newService = await _service_Services.CreateServiceAsync(service);
                if (newService == null)
                {
                    return NotFound();
                }
                return Ok(newService);

            }
            catch (Exception ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }

        }
        [HttpPut]
        [Route("Edit")]

        public async Task<ActionResult<Service>> EditServiceAsync(Guid id, [FromBody] decimal nuevoPrecio)
        {
            try
            {
                await _service_Services.EditServiceAsync(id, nuevoPrecio);
                return Ok("Precio editado exitosamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<Service>> DeteleteServiceAsync(Guid id)
        {
            {
                try
                {

                    var deleteService = await _service_Services.DeteleteServiceAsync(id);

                    if (deleteService == null) return NotFound();

                    return Ok("Borrado satisfactoriamente");
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
        }

        [HttpGet]
        [Route("GetServiceById")]
        public async Task<ActionResult<Service>> GetBarberById(Guid id)
        {

            try
            {
                var service = await _service_Services.GetServiceById(id);
                return Ok(service);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }

        }

        [HttpGet]
        [Route("GetAllService")]
        public async Task<ActionResult<List<Service>>> GetBarbersAsync()
        {
            var services = await _service_Services.GetServicesAsync();

            if (services == null || !services.Any())
            {
                return NotFound();
            }

            return Ok(services);
        }
    }
}


