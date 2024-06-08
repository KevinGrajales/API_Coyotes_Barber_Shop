using API_Coyotes_Barber_Shop.DAL;
using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewById(Guid id)
        {
            return await _context.Reviews.FindAsync(id);
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
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
