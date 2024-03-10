using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;
using System.Data;

namespace ITFestHackathon_API.Repositories.Recipe
{
    public class GetRecipeWithIngredientsRepository : IGetRecipeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetRecipeWithIngredientsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetRecipeResponse>> GetRecipesAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var recipesWithIngredients = await connection.QueryAsync<GetRecipeResponse>("GetRecipesWithIngredients", commandType: CommandType.StoredProcedure);
                return recipesWithIngredients;
            }
        }
    }
}
