namespace HealthIQ.DTOs
{
    public class RecipeDTO
    {
        public string RecipeName { get; set; }
        public string RecipeInstructions { get; set; }
        public int CookingTime { get; set; }
        public string Photo_URL { get; set; }
        public int IdUser { get; set; }
    }
}
