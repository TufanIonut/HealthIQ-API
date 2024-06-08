using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IAddIngredientRepository
    {
        Task<int> AddIngredientAsyncRepo(IngredientDTO ingredientDTO);
    }
}