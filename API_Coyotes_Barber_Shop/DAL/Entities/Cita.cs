namespace API_Coyotes_Barber_Shop.DAL.Entities
{
    public class Cita : AuditBase
    {
        //FK Service
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        //FK Customer
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        //FK Barber
        public Guid BarberId { get; set; }
        public Barber Barber { get; set; }

        // Use DateTime for EF Core compatibility
        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}
