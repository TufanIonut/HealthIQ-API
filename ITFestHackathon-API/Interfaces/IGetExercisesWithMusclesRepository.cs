using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetExercisesWithMusclesRepository
    {
        Task<IEnumerable<ExerciseWithMusclesDTO>> GetExercisesWithMusclesAsyncRepo();
    }
}
