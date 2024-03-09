using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IUpdateRecipeRepository
    {
        Task<int> UpdateRecipeAsyncRepo(UpdateRecipeDTO updateRecipeDTO);
    }
}