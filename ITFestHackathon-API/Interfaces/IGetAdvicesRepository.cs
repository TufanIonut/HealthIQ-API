using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Interfaces
{
    public interface IGetAdvicesRepository
    {
        Task<IEnumerable<GetAdviceResponse>> GetAdvicesAsyncRepo();
    }
}
