using Dapper;
using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Entities;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Recipe
{
    public class UpdateRecipeRepository : IUpdateRecipeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UpdateRecipeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> UpdateRecipeAsyncRepo(UpdateRecipeDTO updateRecipeDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdRecipe", updateRecipeDTO.idRecipe);
            parameters.Add("@RecipeName", updateRecipeDTO.RecipeName);
            parameters.Add("@RecipeInstructions", updateRecipeDTO.RecipeInstructions);
            parameters.Add("@CookingTime", updateRecipeDTO.CookingTime);
            parameters.Add("@PhotoURL", updateRecipeDTO.Photo_URL);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                 await connection.ExecuteAsync("UpdateRecipe", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
