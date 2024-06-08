using System;
using System.ComponentModel.DataAnnotations;

namespace API_Coyotes_Barber_Shop.DTOs
{
    public class ReviewDTO
    {
        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres.")]
        public string Comment { get; set; }

        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Rating { get; set; }
    }
}
