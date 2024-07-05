using HealthIQ.Services;

namespace HealthIQ
{
    public interface IGeneticService
    {
        List<Workout> GenerateWorkoutPlan(User user);
    }
}