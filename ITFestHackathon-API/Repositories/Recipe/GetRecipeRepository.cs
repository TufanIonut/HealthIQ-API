using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;
using System.Data;

namespace ITFestHackathon_API.Repositories.Recipe
{
    public class GetRecipeRepository : IGetRecipeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetRecipeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetRecipeResponse>> GetRecipesAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var recipes = await connection.QueryAsync<GetRecipeResponse>("GetAllRecipes", commandType: CommandType.StoredProcedure);
                return recipes;
            }
        }
    }
}
