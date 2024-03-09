using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;

namespace ITFestHackathon_API.Interfaces
{
    public interface IUpdateWaterConsumptionRepository
    {
        Task<int> UpdateWaterConsumptionAsyncRepo(UpdateWaterConsumptionDTO waterConsumption);
    }
}
