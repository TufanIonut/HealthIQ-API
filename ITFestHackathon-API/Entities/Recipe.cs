namespace ITFestHackathon_API.Entities
{
    public class Recipe
    {
        public int IdRecipe { get; set; }
        public string Recipe_Name { get; set; }
        public string Recipe_Instructions { get; set; }
        public int CookingTime { get; set; }
        public string Photo_URL { get; set; }
        public int IdUser { get; set; }
    }
}
