﻿namespace HealthIQ.DTOs.Update
{
    public class UpdateWaterConsumptionDTO
    {
        //public int IdWaterConsumption; // nu sunt sigur daca are nevoie de asta
        public int IdUser { get; set; }
        public int WaterGlasses { get; set; }
        public DateTime Date { get; set; }
    }
}