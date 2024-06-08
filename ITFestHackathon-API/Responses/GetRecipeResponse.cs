namespace HealthIQ.Responses
{
    public class GetRecipeResponse
    {
        public int IdRecipe { get; set; }
        public string RecipeName { get; set; }
        public string RecipeInstructions { get; set; }
        public int CookingTime { get; set; }
        public string Photo_URL { get; set; }
    }
}
