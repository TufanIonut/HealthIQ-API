namespace HealthIQ.Responses
{
    public class GetWaterConsumptionResponse
    {
        public int IdWaterConsumption { get; set; }
        public int IdUser {  get; set; }
        public int WaterGlasses {  get; set; }
        public DateTime Date {  get; set; }
    }
}