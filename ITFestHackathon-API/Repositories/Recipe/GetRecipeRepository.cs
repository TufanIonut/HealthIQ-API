using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories.Recipe
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
        public async Task<IEnumerable<GetRecipeResponse>> GetRecipesForUser(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var recipes = await connection.QueryAsync<GetRecipeResponse>("GetAllRecipesForUser", parameters, commandType: CommandType.StoredProcedure);
                return recipes;
            }
        }
    }
}
