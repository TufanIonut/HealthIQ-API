using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Interfaces
{
    public interface IGetRecipeIngredientsRepository
    {
        Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipeIngredientsAsyncRepo();
       
    }
}