using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IGetRecipesByTotalCaloriesRepository
    {
        Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipesByTotalCaloriesAsyncRepo(int totalCalories);
    }
}