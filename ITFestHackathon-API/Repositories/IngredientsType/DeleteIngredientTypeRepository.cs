using Dapper;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.IngredientsType
{
    public class DeleteIngredientTypeRepository : IDeleteIngredientTypeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public DeleteIngredientTypeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> DeleteIngredientTypeAsyncRepo(int idIngredientType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TypeId", idIngredientType);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteIngredientType", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
