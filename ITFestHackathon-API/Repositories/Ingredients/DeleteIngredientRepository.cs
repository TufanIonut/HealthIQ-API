using Dapper;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.Ingredients
{
    public class DeleteIngredientRepository : IDeleteIngredientRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public DeleteIngredientRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> DeleteIngredientAsyncRepo(int IngredientId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdIngredient", IngredientId);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteIngredient", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}