using ITFestHackathon_API.DTOs.Update;

namespace ITFestHackathon_API.Interfaces
{
    public interface IUpdateDiseaseRepository
    {
        Task<int> UpdateDiseaseAsyncRepo(UpdateDiseaseDTO disease);
    }
}