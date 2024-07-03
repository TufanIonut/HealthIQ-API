using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Recipe
{
    public class AddRecipeRepository : IAddRecipeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddRecipeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> AddRecipeAsyncRepo(RecipeDTO recipe)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RecipeName", recipe.RecipeName);
            parameters.Add("@RecipeInstructions", recipe.RecipeInstructions);
            parameters.Add("@CookingTime",recipe.CookingTime);
            parameters.Add("@PhotoURL", recipe.Photo_URL);
            parameters.Add("@IdUser", recipe.IdUser);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertRecipe", parameters,commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success"); 
                return result;
            }
        }
    }
}
