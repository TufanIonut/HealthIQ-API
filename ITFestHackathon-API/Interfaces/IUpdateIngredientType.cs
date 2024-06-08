using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IUpdateIngredientTypeRepository
    {
        Task<int> UpdateIngredientTypeAsyncRepo(UpdateIngredientTypeDTO ingredientTypeDTO);
    }
}