using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Interfaces
{
    public interface IGetIngredientsRepository
    {
        Task<IEnumerable<GetIngredientResponse>> GetIngredientsAsyncRepo();
    }
}