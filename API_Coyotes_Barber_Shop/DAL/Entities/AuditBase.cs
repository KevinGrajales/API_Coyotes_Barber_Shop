using System.ComponentModel.DataAnnotations;

namespace API_Coyotes_Barber_Shop.DAL.Entities
{
    public class AuditBase
    {

        [Key] //PK
        [Required] //This field is required
        public virtual Guid  Id { get; set; } // THIS IS THE PRIMARY KEY OF ALL TABLES 

     

    }
}
