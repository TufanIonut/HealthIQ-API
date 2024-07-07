using HealthIQ.DTOs;
using HealthIQ.Requests;
using HealthIQ.Responses;

namespace HealthIQ.Repositories
{
    public interface ISupplementsRepository
    {
        Task<IEnumerable<PillsResponse>> GetPills();
        Task<bool> insertMeds(MedsDTO meds);
        Task<IEnumerable<MedsResponse>> GetMeds();
        Task<int> DeleteMeds(int id);
        Task<int> ToogleTaken(int id);
        Task<IEnumerable<ManufacturerResponse>> GetManufacturers();
        Task<int> InsertPillAsync(AddPillRequest addPillRequest);
    }
}