using Dapper;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.Recipe
{
    public class DeleteRecipeRepository : IDeleteRecipeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public DeleteRecipeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> DeleteRecipeAsyncRepo(int idRecipe)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdRecipe", idRecipe);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteRecipe", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }

    }
}
