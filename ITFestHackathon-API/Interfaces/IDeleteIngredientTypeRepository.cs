namespace ITFestHackathon_API.Interfaces
{
    public interface IDeleteIngredientTypeRepository
    {
        Task<int> DeleteIngredientTypeAsyncRepo(int idIngredientType);
    }
}