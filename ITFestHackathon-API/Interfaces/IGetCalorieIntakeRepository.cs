using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetCalorieIntakeRepository
    {
        Task<IEnumerable<RecommendedCalorieIntakeDTO>> GetCalorieIntakeAsyncRepo(int userId);
    }
}