using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IUpdateDiseaseRepository
    {
        Task<int> UpdateDiseaseAsyncRepo(UpdateDiseaseDTO disease);
    }
}