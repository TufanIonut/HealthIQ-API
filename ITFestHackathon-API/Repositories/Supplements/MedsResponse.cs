namespace HealthIQ.Repositories
{
    public class MedsResponse
    {
        public int IdMedication { get; set; }
        public int IdUser { get; set; }
        public string PillName { get; set; }
        public string TakingHour { get; set; }
        public int TimesPerDay { get; set; }
        public bool Taken { get; set; }
    }
}