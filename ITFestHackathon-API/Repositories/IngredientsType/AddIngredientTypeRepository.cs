using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.IngredientsType
{
    public class AddIngredientTypeRepository : IAddIngredientTypeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddIngredientTypeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> AddIngredientTypeAsyncRepo(IngredientTypeDTO ingredientType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Type", ingredientType.Type);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("AddIngredientType", parameters,commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
