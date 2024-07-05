using HealthIQ.Requests;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IReviewsRepository
    {
        Task<int> AddReviewAsync(AddReviewRequest addReviewRequest);
        Task<IEnumerable<ReviewsResponse>> GetReviewsAsync();
        Task<IEnumerable<UserReviewRespose>> GetUserReviewsAsync(int idUser);
        Task<int> DeleteReview(int idReview);
    }
}