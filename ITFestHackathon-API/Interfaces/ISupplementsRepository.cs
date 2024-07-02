using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Repositories
{
    public interface ISupplementsRepository
    {
        Task<IEnumerable<PillsResponse>> GetPills();
        Task<bool> insertMeds(MedsDTO meds);
        Task<IEnumerable<MedsResponse>> GetMeds();
        Task<int> DeleteMeds(int id);
    }
}