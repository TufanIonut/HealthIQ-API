using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetIngredientTypesRepository
    {
        Task<IEnumerable<GetIngredientTypeResponse>> GetIngredientTypesAsyncRepo();
    }
}