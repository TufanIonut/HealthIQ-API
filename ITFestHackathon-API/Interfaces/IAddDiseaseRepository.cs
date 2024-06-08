using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IAddDiseaseRepository
    {
        Task<int> AddDiseaseAsyncRepo(DiseaseDTO disease);
    }
}