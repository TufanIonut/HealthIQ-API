namespace ITFestHackathon_API.Entities
{
    public class WaterConsumption
    {
        public int IdWaterConsumption { get; set; }
        public int IdUser {  get; set; }
        public int WaterGlasses { get; set; }
        public string Date { get; set; }
    }
}