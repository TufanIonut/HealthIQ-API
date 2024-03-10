using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IAddRecipeWithIngredientsRepository
    {
        Task<int> AddRecipeWithIngredientsAsyncRepo(RecipeWithIngredientsDTO recipeWithIngredientsDTO);
    }
}