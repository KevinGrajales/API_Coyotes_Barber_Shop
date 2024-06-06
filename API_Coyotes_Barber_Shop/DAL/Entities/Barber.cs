using System.ComponentModel.DataAnnotations;

namespace API_Coyotes_Barber_Shop.DAL.Entities
{
    public class Barber : AuditBase
    {
        [Display(Name = "NombreBarbero")] // name identifier
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo 20 caracteres")] //length field
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Obligatory field  
        public string Name { get; set; }

        [Display(Name = "ApellidoBarbero")] // name identifier
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo 20 caracteres")] //length field
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Obligatory field  
        public string LastName { get; set; }

        [Display(Name = "CelularBarbero")] // name identifier
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener maximo 10 caracteres")] //length field
        public int Celphone { get; set; }

        [Display(Name = "CorreoBarbero")] // name identifier
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo 50 caracteres")] //length field
        public string? Email { get; set; }

    }
}
