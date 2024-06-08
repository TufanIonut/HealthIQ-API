using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface ILoginUserRepository
    {
        Task<int> LoginUserAsyncRepo(UserCredentialsDTO userCredentialsDTO);
    }
}