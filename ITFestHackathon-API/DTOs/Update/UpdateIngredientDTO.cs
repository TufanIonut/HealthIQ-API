﻿namespace ITFestHackathon_API.DTOs.Update
{
    public class UpdateIngredientDTO
    {
        public int IdIngredient { get; set; }
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        public float CaloriesNOPer100g { get; set; }
        public float ProteinNoPer100g { get; set; }
        public float CarboNoPer100g { get; set; }
        public float FatsNoPer100g { get; set; }
    }
}
