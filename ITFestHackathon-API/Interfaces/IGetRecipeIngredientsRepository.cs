using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetRecipeIngredientsRepository
    {
        Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipeIngredientsAsyncRepo();
        Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipeIngredientsForUserAsyncRepo(int idUser);
       
    }
}