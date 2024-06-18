namespace HealthIQ.Responses
{
    public class GetUserInfoResponse
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public int Height { get; set; }
        public string FitLevel { get; set; }
        public int TrainingFrequency { get; set; }
        public string UserTarget { get; set; }
        public string Gender { get; set; }
        public string ProfilePic_URL { get; set; }
        public int Points { get; set; }
    }
}

