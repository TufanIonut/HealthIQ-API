using HealthIQ.Interfaces;
using HealthIQ.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository _reviewsRepository;
        public ReviewsController(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        [HttpGet]
        [Route("GetAllReviews")]
        public async Task<IActionResult> GetReviews()
        {
            var result =  await _reviewsRepository.GetReviewsAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReviewById")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var result = await _reviewsRepository.GetUserReviewsAsync(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddReview")]
        public async Task<IActionResult> AddReview(AddReviewRequest review)
        {
            var result = await _reviewsRepository.AddReviewAsync(review);
            if (result == -1)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
