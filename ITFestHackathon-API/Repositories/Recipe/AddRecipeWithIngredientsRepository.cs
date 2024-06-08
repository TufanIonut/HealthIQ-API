using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Recipe
{
    public class AddRecipeWithIngredientsRepository : IAddRecipeWithIngredientsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddRecipeWithIngredientsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }



        public async Task<int> AddRecipeWithIngredientsAsyncRepo(RecipeWithIngredientsDTO recipeWithIngredientsDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdRecipe", recipeWithIngredientsDTO.IdRecipe);
            parameters.Add("@IdIngredient", recipeWithIngredientsDTO.IdIngredient);
            parameters.Add("@Grams", recipeWithIngredientsDTO.Grams);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("AddRecipeWithIngredients", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}