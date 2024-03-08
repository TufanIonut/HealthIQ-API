using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface ILoginUserRepository
    {
        Task<int> LoginUserAsyncRepo(UserCredentialsDTO userCredentialsDTO);
    }
}