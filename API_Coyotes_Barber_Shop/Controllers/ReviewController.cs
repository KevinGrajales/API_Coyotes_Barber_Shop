using API_Coyotes_Barber_Shop.DAL.Entities;
using API_Coyotes_Barber_Shop.Domain.Interfaces;
using API_Coyotes_Barber_Shop.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Coyotes_Barber_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewResponseDTO>>> GetAllReviews()
        {
            return Ok(await _reviewService.GetAllReviews());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewResponseDTO>> GetReviewById(Guid id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview([FromBody] ReviewDTO reviewDto)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                ServiceId = reviewDto.ServiceId,
                CustomerId = reviewDto.CustomerId,
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
                Date = DateTime.UtcNow
            };

            await _reviewService.CreateReview(review);
            var reviewResponse = await _reviewService.GetReviewById(review.Id);
            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, reviewResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(Guid id, [FromBody] ReviewDTO reviewDto)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var review = new Review
            {
                Id = id,
                ServiceId = reviewDto.ServiceId,
                CustomerId = reviewDto.CustomerId,
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
                Date = DateTime.UtcNow
            };

            await _reviewService.UpdateReview(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            await _reviewService.DeleteReview(id);
            return NoContent();
        }
    }
}
