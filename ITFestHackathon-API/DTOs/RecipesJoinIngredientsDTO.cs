namespace ITFestHackathon_API.DTOs
{
    public class RecipesJoinIngredientsDTO
    {
        public int IdRecipeIngredients {  get; set; }
        public string RecipeName { get; set; }
        public string RecipeInstructions { get; set; }
        public int CookingTime { get; set; }
        public string Photo_URL { get; set; }
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        public float CaloriesNOPer100g { get; set; }
        public float ProteinNoPer100g { get; set; }
        public float CarboNoPer100g { get; set; }
        public float FatsNoPer100g { get; set; }
    }
}