using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;

namespace ITFestHackathon_API.Interfaces
{
    public interface IGetWorkoutPlanRepository
    {
        Task<IEnumerable<WorkoutPlanDTO>> GetWorkputPlanAsyncRepo(int idUser);
    }
}