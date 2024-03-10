using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IAddWaterConsumptionRepository
    {
        Task<int> AddWaterConsumptionAsyncRepo(WaterConsumptionDTO waterConsumptionDTO);
    }
}