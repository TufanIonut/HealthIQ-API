namespace HealthIQ.Requests
{
    public class UserWeightRequest
    {
        public int IdUser { get; set; }
        public float Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
