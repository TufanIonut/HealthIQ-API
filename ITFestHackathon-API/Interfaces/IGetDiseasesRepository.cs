using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;

namespace HealthIQ.Interfaces
{
    public interface IGetDiseasesRepository
    {
        Task<IEnumerable<UpdateDiseaseDTO>> GetDiseasesAsyncRepo();
    }
}