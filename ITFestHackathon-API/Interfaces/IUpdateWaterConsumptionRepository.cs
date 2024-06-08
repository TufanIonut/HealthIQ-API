using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IUpdateWaterConsumptionRepository
    {
        Task<int> UpdateWaterConsumptionAsyncRepo(UpdateWaterConsumptionDTO waterConsumption);
    }
}
