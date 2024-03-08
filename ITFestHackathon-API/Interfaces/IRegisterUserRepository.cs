using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IRegisterUserRepository
    {
        Task<int> RegisterUserAsyncRepo(UserCredentialsDTO userCredentialsDTO);
    }
}