using HealthIQ.DTOs;
using HealthIQ.Requests;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetExercisesWithMusclesRepository
    {
        Task<IEnumerable<ExerciseWithMusclesDTO>> GetExercisesWithMusclesAsyncRepo();
        Task<IEnumerable<MuscleGroupsResponse>> GetMuscleGroupsAsyncRepo();
        Task<int> AddExerciseAsyncRepo(AddExerciseRequest addExerciseRequest);
    }
}
