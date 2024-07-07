using HealthIQ.Entities;
using HealthIQ.Services;

namespace HealthIQ.Requests
{
    public class AddExerciseRequest
    {
        public string ExerciseName { get; set; }
        public string DifficultyLevel { get; set; }
        public string ExerciseLink { get; set; }
        public string MuscleGroupName { get; set; }
        public string MuscleGroupSecondary { get; set; }

    }
}
