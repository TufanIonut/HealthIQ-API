using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IAddIngredientRepository
    {
        Task<int> AddIngredientAsyncRepo(IngredientDTO ingredientDTO);
    }
}