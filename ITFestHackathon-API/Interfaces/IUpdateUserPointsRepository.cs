using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;

namespace ITFestHackathon_API.Interfaces
{
    public interface IUpdateUserPointsRepository
    {
        Task<int> UpdateUserPointsAsyncRepo(UpdateUserPointsDTO userPointsDTO);
    }
}