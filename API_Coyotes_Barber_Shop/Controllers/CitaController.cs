using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API_Coyotes_Barber_Shop.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using API_Coyotes_Barber_Shop.Domain.Services;

namespace API_Coyotes_Barber_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : Controller
    {
        private readonly ICitaServices _citaServices;

        public CitaController(ICitaServices citaServices)
        {
            _citaServices = citaServices;
        }

        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult<Cita>> CreateCitaAsync([FromBody] CitaRequest request)
        {

            try
            {
                var newCita = await _citaServices.CreateCitaAsync(request.ServiceId, request.NameService, request.CustomerId, request.NameCustomer, request.BarberId, request.NameBarber, request.Date, request.Time, request.Price);
                return Ok(newCita);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }


        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Cita>> GetCitaByIdAsync(Guid id)
        {
            try
            {
                var cita = await _citaServices.GetCitaByIdAsync(id);
                return Ok(cita);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitaAsync()
        {

            var citas = await _citaServices.GetCitaAsync();
            if (citas == null || !citas.Any()) return NotFound();

            return Ok(citas);


        }


        [HttpGet]
        [Route("GetAllCitasBarberById")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitaByBarberIdAsync(Guid barberId)
        {

            var citas = await _citaServices.GetCitaByBarberIdAsync(barberId);
            return Ok(citas);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<Cita>> UpdateCitaAsync(Guid id, [FromBody] CitaRequest request)
        {
            try
            {

                var citaUpdate = await _citaServices.UpdateCitaAsync(id, request.ServiceId, request.NameService, request.CustomerId, request.NameCustomer, request.BarberId, request.NameBarber, request.Date, request.Time, request.Price);

                if (citaUpdate== null)
                {
                    return NotFound();
                }

                return Ok(citaUpdate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<Cita>> DeleteCitaAsync(Guid id)
        {
            try
            {

                var deleteCita = await _citaServices.DeleteCitaAsync(id);

                if (deleteCita == null) return NotFound();

                return Ok("Borrado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Payment")]
        public async Task<ActionResult<Cita>> PayCiteAsync(Guid id)
        {
            try
            {
                var updatePayment = await _citaServices.PayCiteAsync(id);
                if (updatePayment == null) return NotFound();
                return Ok(updatePayment);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }
        }

    }
}


public class CitaRequest
{
    public Guid ServiceId { get; set; }
    public string NameService { get; set; }

    public Guid CustomerId { get; set; }
    public string NameCustomer { get; set; }
    public Guid BarberId { get; set; }
    public string NameBarber { get; set; }

    public DateTime Date { get; set; }

    [RegularExpression(@"^(?:[01]\d|2[0-3]):(?:[0-5]\d)$", ErrorMessage = "El formato de la hora no es válido.")]
    public string Time { get; set; }

    public decimal Price { get; set; }

}
