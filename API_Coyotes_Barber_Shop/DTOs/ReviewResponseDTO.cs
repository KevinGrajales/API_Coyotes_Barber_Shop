using System;

namespace API_Coyotes_Barber_Shop.DTOs
{
    public class ReviewResponseDTO
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
