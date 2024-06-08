using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IGetRecipesByTotalCaloriesRepository
    {
        Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipesByTotalCaloriesAsyncRepo(int totalCalories);
    }
}