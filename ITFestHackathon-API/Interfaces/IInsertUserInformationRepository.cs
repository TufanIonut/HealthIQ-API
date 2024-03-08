using ITFestHackathon_API.DTOs;

namespace ITFestHackathon_API.Interfaces
{
    public interface IInsertUserInformationRepository
    {
        Task<int> InsertUserInformationAsyncRepo(UserInformationDTO userInformationDTO);
    }
}