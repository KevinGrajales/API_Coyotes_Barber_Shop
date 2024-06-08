using System.ComponentModel.DataAnnotations;

namespace API_Coyotes_Barber_Shop.DAL.Entities
{
    public class Cita : AuditBase
    {
        //FK Service
        public Guid ServiceId { get; set; }
        public string NameService { get; set; }
        public Service Service { get; set; }

        //FK Customer
        public Guid CustomerId { get; set; }
        public string NameCustomer { get; set; }
        public Customer Customer { get; set; }

        //FK Barber
        public Guid BarberId { get; set; }
        public string NameBarber { get; set; }
        public Barber Barber { get; set; }

        public DateTime Date { get; set; }

        [RegularExpression(@"^(?:[01]\d|2[0-3]):(?:[0-5]\d)$", ErrorMessage = "El formato de la hora no es válido.")]
        public string Time { get; set; }

        public decimal Price { get; set; }

        public bool Payment { get; set; }

    }
}
