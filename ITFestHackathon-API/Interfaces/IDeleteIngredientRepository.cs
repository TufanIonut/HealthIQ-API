namespace ITFestHackathon_API.Interfaces
{
    public interface IDeleteIngredientRepository
    {
        Task<int> DeleteIngredientAsyncRepo(int IngredientId);
    }
}