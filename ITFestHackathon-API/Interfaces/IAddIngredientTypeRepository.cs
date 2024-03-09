using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IAddIngredientTypeRepository
    {
        Task<int> AddIngredientTypeAsyncRepo(IngredientTypeDTO ingredientTypeDTO);
    }
}