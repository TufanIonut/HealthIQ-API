using HealthIQ.DTOs;

namespace HealthIQ.Interfaces
{
    public interface IRegisterUserRepository
    {
        Task<int> RegisterUserAsyncRepo(UserCredentialsDTO userCredentialsDTO);
    }
}