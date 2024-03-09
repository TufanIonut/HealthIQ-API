using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IAddDiseaseRepository
    {
        Task<int> AddDiseaseAsyncRepo(DiseaseDTO disease);
    }
}