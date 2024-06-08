using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IAddRecipeWithIngredientsRepository
    {
        Task<int> AddRecipeWithIngredientsAsyncRepo(RecipeWithIngredientsDTO recipeWithIngredientsDTO);
    }
}