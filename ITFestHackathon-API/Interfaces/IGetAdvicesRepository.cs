using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetAdvicesRepository
    {
        Task<IEnumerable<GetAdviceResponse>> GetAdvicesAsyncRepo();
    }
}
