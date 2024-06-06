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

        [Display(Name = "CelularCliente")] // name identifier
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener maximo 10 caracteres")] //length field
        public int? Celular { get; set; }

        [Display(Name = "CorreoCliente")] // name identifier
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo 50 caracteres")] //length field
        public string? Correo { get; set; }



    }
}
