using Dapper;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Recipe
{
    public class DeleteRecipeWithIngredientsRepository : IDeleteRecipeWithIngredientsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public DeleteRecipeWithIngredientsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> DeleteRecipeWithIngredientsAsyncRepo(int idRecipeWithIngredients)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdRecipeIngredient", idRecipeWithIngredients);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteRecipeWithIngredients", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }

    }
}
