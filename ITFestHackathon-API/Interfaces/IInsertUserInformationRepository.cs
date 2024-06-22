using HealthIQ.DTOs;
using HealthIQ.Requests;

namespace HealthIQ.Interfaces
{
    public interface IInsertUserInformationRepository
    {
        Task<int> InsertUserInformationAsyncRepo(UserInformationDTO userInformationDTO);
        Task<int> InsertWeightHistory(UserWeightRequest userWeightRequest);
    }
}