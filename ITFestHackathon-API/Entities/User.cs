namespace ITFestHackathon_API.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string FitLevel { get; set; }
        public int TrainingFrequency { get; set; }
        public string UserTarget { get; set; }
        public int Gender { get; set; }
        public int Points { get; set; } 
        public int ProfilePic_URL { get; set; }

    }
}
