using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IAddRecipeRepository
    {
        Task<int> AddRecipeAsyncRepo(RecipeDTO recipe);
    }
}