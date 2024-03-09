namespace ITFestHackathon_API.Interfaces
{
    public interface IDeleteRecipeRepository
    {
        Task<int> DeleteRecipeAsyncRepo(int idRecipe);
    }
}