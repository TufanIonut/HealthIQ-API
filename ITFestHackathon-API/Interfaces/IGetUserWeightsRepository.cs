using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetUserWeightsRepository
    {
        Task<IEnumerable<UserWeightResponse>> GetUserWeightsAsyncRepo(int idUser);
    }
}