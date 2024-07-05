namespace HealthIQ.Services
{
    public class User
    {
        public int Height { get; }
        public int Weight { get; }
        public string Gender { get; }
        public int TrainingFrequency { get; }
        public DateTime BirthDate { get; }
        public string FitLevel { get; }

        public User(int height, int weight, string gender, int trainingFrequency, DateTime birthDate, string fitLevel)
        {
            Height = height;
            Weight = weight;
            Gender = gender;
            TrainingFrequency = trainingFrequency;
            BirthDate = birthDate;
            FitLevel = fitLevel;
        }
    }
}
