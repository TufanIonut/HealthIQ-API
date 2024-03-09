namespace ITFestHackathon_API.DTOs
{
    public class UserInformationDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string FitLevel { get; set; }
        public int TrainingFrequency { get; set; }
        public string UserTarget { get; set; }
        public string? Gender { get; set; }
    }
}
