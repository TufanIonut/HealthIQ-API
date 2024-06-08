namespace HealthIQ.Interfaces
{
    public interface IDeleteRecipeRepository
    {
        Task<int> DeleteRecipeAsyncRepo(int idRecipe);
    }
}