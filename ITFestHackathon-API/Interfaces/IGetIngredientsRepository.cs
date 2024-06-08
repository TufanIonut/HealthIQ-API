using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetIngredientsRepository
    {
        Task<IEnumerable<GetIngredientResponse>> GetIngredientsAsyncRepo();
    }
}