namespace ITFestHackathon_API.Entities
{
    public class WorkoutExercise
    {
        public int IdWorkoutExercises { get; set; }
        public int IdWorkout { get; set; }
        public int IdExercise { get; set; }
        public int Sets_Count { get; set; }
        public int Reps_Count { get; set; }
        public int Rest_Between_Sets_In_Minutes { get; set; }
    }
}
