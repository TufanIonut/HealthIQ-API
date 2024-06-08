namespace HealthIQ.Interfaces
{
    public interface IDeleteIngredientRepository
    {
        Task<int> DeleteIngredientAsyncRepo(int IngredientId);
    }
}