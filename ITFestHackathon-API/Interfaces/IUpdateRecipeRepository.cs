using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IUpdateRecipeRepository
    {
        Task<int> UpdateRecipeAsyncRepo(UpdateRecipeDTO updateRecipeDTO);
    }
}