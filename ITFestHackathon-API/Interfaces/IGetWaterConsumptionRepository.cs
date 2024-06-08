using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetWaterConsumptionRepository
    {
        Task<IEnumerable<GetWaterConsumptionResponse>> GetWaterConsumptionAsyncRepo(int IdUser);
    }
}