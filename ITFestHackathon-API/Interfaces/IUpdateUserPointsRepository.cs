using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IUpdateUserPointsRepository
    {
        Task<int> UpdateUserPointsAsyncRepo(UpdateUserPointsDTO userPointsDTO);
    }
}