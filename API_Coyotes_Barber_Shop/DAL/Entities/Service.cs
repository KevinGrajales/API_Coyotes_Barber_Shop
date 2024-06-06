using System.ComponentModel.DataAnnotations;

namespace API_Coyotes_Barber_Shop.DAL.Entities
{
    public class Service : AuditBase
    {
        [Display(Name = "NombreCliente")] // name identifier
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo 20 caracteres")] //length field
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Obligatory field  
        public string Name { get; set; }

        [Display(Name = "ValorServicio")] // name identifier
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] // Obligatory field  
        [Range(10000, 60000, ErrorMessage = "El campo {0} debe estar entre 10.000 y 60.000")]
        public decimal Precio { get; set; }



    }
}
