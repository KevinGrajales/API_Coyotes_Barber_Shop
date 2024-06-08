using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API_Coyotes_Barber_Shop.DAL.Entities;
using System.ComponentModel.DataAnnotations;

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

        public async Task<ActionResult<Cita>> CreateCitaAsync([FromBody] CreateCitaRequest request)
        {

            try
            {
                var newCita = await _citaServices.CreateCitaAsync(request.ServiceId, request.NameService, request.CustomerId, request.NameCustomer, request.BarberId, request.NameBarber, request.Date, request.Time, request.Price, request.Payment);
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

    }
}


public class CreateCitaRequest
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

    public bool Payment { get; set; }

}
