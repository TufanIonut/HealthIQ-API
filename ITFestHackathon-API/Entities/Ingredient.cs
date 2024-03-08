namespace ITFestHackathon_API.Entities
{
    public class Ingredient
    {
        public int IdIngredient { get; set; }
        public String Ingredient_Name {  get; set; }
        public int IdIngredientType {  get; set; }
        public float CaloriesNumberPer100g {  get; set; }
        public float ProteinNumber {  get; set; }
        public float CarbohidrateNumber {  get; set; }
        public float FatsNumber {  get; set; }

    }
}
