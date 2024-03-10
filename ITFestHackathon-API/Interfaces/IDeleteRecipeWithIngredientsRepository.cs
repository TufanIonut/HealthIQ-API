using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IDeleteRecipeWithIngredientsRepository
    {
        Task<int> DeleteRecipeWithIngredientsAsyncRepo(int idRecipeWithIngredients);
    }
}