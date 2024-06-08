using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IGetWorkoutPlanRepository
    {
        Task<IEnumerable<WorkoutPlanDTO>> GetWorkputPlanAsyncRepo(int idUser);
    }
}