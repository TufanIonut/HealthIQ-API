using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IAddRecipeRepository
    {
        Task<int> AddRecipeAsyncRepo(RecipeDTO recipe);
    }
}