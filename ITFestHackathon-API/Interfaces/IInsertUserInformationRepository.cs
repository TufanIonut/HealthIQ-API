using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IInsertUserInformationRepository
    {
        Task<int> InsertUserInformationAsyncRepo(UserInformationDTO userInformationDTO);
    }
}