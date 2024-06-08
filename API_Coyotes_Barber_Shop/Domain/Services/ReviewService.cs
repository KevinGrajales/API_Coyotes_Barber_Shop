using API_Coyotes_Barber_Shop.DAL;
using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;
using API_Coyotes_Barber_Shop.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Coyotes_Barber_Shop.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext _context;

        public ReviewService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReviewResponseDTO>> GetAllReviews()
        {
            return await _context.Reviews
                .Include(r => r.Customer) // Incluir entidad relacionada Customer
                .Select(r => new ReviewResponseDTO
                {
                    Id = r.Id,
                    CustomerName = $"{r.Customer.Name} {r.Customer.LastName}",
                    Comment = r.Comment,
                    Rating = r.Rating,
                    Date = r.Date
                })
                .ToListAsync();
        }

        public async Task<ReviewResponseDTO> GetReviewById(Guid id)
        {
            var review = await _context.Reviews
                .Include(r => r.Customer)
                .Where(r => r.Id == id)
                .Select(r => new ReviewResponseDTO
                {
                    Id = r.Id,
                    CustomerName = $"{r.Customer.Name} {r.Customer.LastName}",
                    Comment = r.Comment,
                    Rating = r.Rating,
                    Date = r.Date
                })
                .FirstOrDefaultAsync();

            return review;
        }

        public async Task CreateReview(Review review)
        {
            review.Date = DateTime.UtcNow;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReview(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReview(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
