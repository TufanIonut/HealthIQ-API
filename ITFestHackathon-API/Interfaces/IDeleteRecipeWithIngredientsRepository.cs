using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IDeleteRecipeWithIngredientsRepository
    {
        Task<int> DeleteRecipeWithIngredientsAsyncRepo(int idRecipeWithIngredients);
    }
}