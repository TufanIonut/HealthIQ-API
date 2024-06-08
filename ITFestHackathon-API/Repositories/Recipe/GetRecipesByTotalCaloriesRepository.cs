using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Recipe
{
    public class GetRecipesByTotalCaloriesRepository : IGetRecipesByTotalCaloriesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetRecipesByTotalCaloriesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipesByTotalCaloriesAsyncRepo(int totalCalories)
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var recipes = await connection.QueryAsync<RecipesJoinIngredientsDTO>("GetRecipesByTotalCalories", new { TotalCalories = totalCalories }, commandType: CommandType.StoredProcedure);
                return recipes;
            }
        }
    }
}
