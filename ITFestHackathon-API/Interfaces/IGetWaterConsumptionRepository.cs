using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Interfaces
{
    public interface IGetWaterConsumptionRepository
    {
        Task<IEnumerable<GetWaterConsumptionResponse>> GetWaterConsumptionAsyncRepo(int IdUser);
    }
}