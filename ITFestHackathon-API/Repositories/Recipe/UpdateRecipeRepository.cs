using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Entities;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.Recipe
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
