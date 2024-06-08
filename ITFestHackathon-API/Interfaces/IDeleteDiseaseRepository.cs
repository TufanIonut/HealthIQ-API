namespace HealthIQ.Interfaces
{
    public interface IDeleteDiseaseRepository
    {
        Task<int> DeleteDiseaseAsyncRepo(int DiseaseId);
    }
}