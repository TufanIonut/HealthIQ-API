using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetUserInfoRepository
    {
        Task<IEnumerable<GetUserInfoResponse>> GetUserInfoAsyncRepo(int idUser);
        Task<IEnumerable<AllUsersResponse>> GetAllUsersAsyncRepo();
    }
}