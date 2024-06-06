using System.ComponentModel.DataAnnotations;

namespace API_Coyotes_Barber_Shop.DAL.Entities
{
    public class Customer : AuditBase
    {
        [Display(Name = "NombreCliente" )] // name identifier
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo 20 caracteres")] //length field
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Obligatory field  
        public string Name { get; set; }

        [Display(Name = "ApellidoCliente")] // name identifier
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo 20 caracteres")] //length field
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Obligatory field  
        public string LastName { get; set; }

        [Display(Name = "CelularBarbero")] // name identifier
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de celular debe tener exactamente 10 dígitos y solo puede contener números.")]//length field
        public string CelPhone { get; set; }

        [Display(Name = "CorreoBarbero")] // name identifier
        [EmailAddress(ErrorMessage = "El formato del correo es inválido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo 50 caracteres")] //length field
        public string Email { get; set; }



    }
}
