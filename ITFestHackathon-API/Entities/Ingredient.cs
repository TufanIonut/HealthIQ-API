namespace ITFestHackathon_API.Entities
{
    public class Ingredient
    {
        public int IdIngredient { get; set; }
        public string Ingredient_Name {  get; set; }
        public int IdIngredientType {  get; set; }
        public float CaloriesNOPer100g {  get; set; }
        public float ProteinNoPer100g {  get; set; }
        public float CarboNoPer100g {  get; set; }
        public float FatsNoPer100g {  get; set; }

    }
}
