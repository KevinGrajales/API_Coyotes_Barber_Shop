using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API_Coyotes_Barber_Shop.DAL.Entities;
using System.Diagnostics.Metrics;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API_Coyotes_Barber_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberController : Controller
    {
        private readonly IBarberServices _barberServices;

        public BarberController(IBarberServices barberServices)
        {
            _barberServices = barberServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAllBarbes")]
        public async Task<ActionResult<List<Barber>>> GetBarbersAsync()
        {
            var barbers = await _barberServices.GetBarbersAsync();

            if (barbers == null || !barbers.Any())
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        [HttpGet]
        [Route("GetBarberById")]
        public async Task<ActionResult<Barber>> GetBarberById(Guid id)
        {
            var barber = await _barberServices.GetBarberById(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }




        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<Barber>> DeleteBarberAsync(Guid id)
        {
            try
            {

                var deleteBarber = await _barberServices.DeleteBarberAsync(id);

                if (deleteBarber == null) return NotFound();

                return Ok("Borrado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost, ActionName("CreateBarber")]
        [Route("Create")]
        public async Task<ActionResult<Barber>> CreateBarberAsync(Barber barber)
        {
            try
            {
                var newBarber = await _barberServices.CreateBarberAsync(barber);
                if (newBarber == null)
                {
                    return NotFound();
                }
                return Ok(newBarber);

            }
            catch (Exception ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }


        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<Barber>> EditBarberAsync(Guid id, [FromBody] UpdateBarberoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok("Correo o celular incorrecto");
                }

                var barberUpdate = await _barberServices.EditBarberAsync(id, request.Email, request.CelPhone);
                if (barberUpdate == null)
                {
                    return NotFound();
                }

                return Ok(barberUpdate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

public class UpdateBarberoRequest
{
    [EmailAddress(ErrorMessage = "El formato del correo es inválido.")] //
    public string Email { get; set; }

    [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de celular debe tener exactamente 10 dígitos y solo puede contener números.")] //
    public string CelPhone { get; set; }
}
