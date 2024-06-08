using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IUpdateIngredientRepository
    {
        Task<int> UpdateIngredientAsyncRepo(UpdateIngredientDTO ingredientDTO);
    }
}