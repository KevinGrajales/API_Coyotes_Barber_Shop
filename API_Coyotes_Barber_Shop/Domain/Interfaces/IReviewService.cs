using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Coyotes_Barber_Shop.Domain.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewResponseDTO>> GetAllReviews();
        Task<ReviewResponseDTO> GetReviewById(Guid id);
        Task CreateReview(Review review);
        Task UpdateReview(Review review);
        Task DeleteReview(Guid id);
    }
}
