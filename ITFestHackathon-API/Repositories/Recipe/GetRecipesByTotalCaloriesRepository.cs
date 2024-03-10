using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.Recipe
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
