namespace ITFestHackathon_API.DTOs
{
    public class UpdateRecipeDTO
    {
        public int idRecipe {  get; set; }
        public string RecipeName { get; set; }
        public string RecipeInstructions { get; set; }
        public int CookingTime { get; set; }
        public string Photo_URL { get; set; }
    }
}
