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
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerService;

        public CustomerController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync()
        {
            var customers = await _customerService.GetCustomersAsync();

            if (customers == null || !customers.Any())
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<ActionResult<Customer>> GetCustomerById(Guid id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            
            }
            catch (ArgumentException ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }

        }



        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<Customer>> DeleteCustomerAsync(Guid id)
        {
            try
            {

                var deleteCustomer = await _customerService.DeleteCustomerAsync(id);
                if (deleteCustomer == null) return NotFound();

                return Ok("Borrado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost, ActionName("CreateCustomer")]
        [Route("Create")]
        public async Task<ActionResult<Barber>> CreateCustomerAsync(Customer customer)
        {
            try
            {
                var newCustomer = await _customerService.CreateCustomerAsync(customer);
                if (newCustomer == null)
                {
                    return NotFound();
                }
                return Ok(newCustomer);

            }
            catch (Exception ex)
            {
                return StatusCode(200, new { message = ex.Message });
            }


        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<Customer>> EditCustomerAsync(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok("Correo o celular incorrecto");
                }

                var barberUpdate = await _customerService.EditCustomerAsync(id, request.Email, request.CelPhone);
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

public class UpdateCustomerRequest
{
    [EmailAddress(ErrorMessage = "El formato del correo es inválido.")] //
    public string Email { get; set; }

    [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de celular debe tener exactamente 10 dígitos y solo puede contener números.")] //
    public string CelPhone { get; set; }
}