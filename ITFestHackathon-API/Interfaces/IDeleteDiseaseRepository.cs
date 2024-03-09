namespace ITFestHackathon_API.Interfaces
{
    public interface IDeleteDiseaseRepository
    {
        Task<int> DeleteDiseaseAsyncRepo(int DiseaseId);
    }
}