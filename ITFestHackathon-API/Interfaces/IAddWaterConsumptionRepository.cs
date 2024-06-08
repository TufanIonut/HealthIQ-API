using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IAddWaterConsumptionRepository
    {
        Task<int> AddWaterConsumptionAsyncRepo(WaterConsumptionDTO waterConsumptionDTO);
    }
}