namespace HealthIQ.Interfaces
{
    public interface IDeleteIngredientTypeRepository
    {
        Task<int> DeleteIngredientTypeAsyncRepo(int idIngredientType);
    }
}