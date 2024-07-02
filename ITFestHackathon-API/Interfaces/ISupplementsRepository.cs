using HealthIQ.Responses;

namespace HealthIQ.Repositories
{
    public interface ISupplementsRepository
    {
        Task<IEnumerable<PillsResponse>> GetPills();
        Task<bool> insertMeds(MedsDTO meds);
        Task<IEnumerable<MedsDTO>> GetMeds();
    }
}