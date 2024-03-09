using ITFestHackathon_API.DTOs.Update;

namespace ITFestHackathon_API.Interfaces
{
    public interface IUpdateIngredientRepository
    {
        Task<int> UpdateIngredientAsyncRepo(UpdateIngredientDTO ingredientDTO);
    }
}