using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IAddIngredientTypeRepository
    {
        Task<int> AddIngredientTypeAsyncRepo(IngredientTypeDTO ingredientTypeDTO);
    }
}