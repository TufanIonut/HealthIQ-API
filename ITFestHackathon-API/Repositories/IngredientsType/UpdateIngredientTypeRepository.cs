using Dapper;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.IngredientsType
{
    public class UpdateIngredientTypeRepository : IUpdateIngredientTypeRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public UpdateIngredientTypeRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> UpdateIngredientTypeAsyncRepo(UpdateIngredientTypeDTO ingredientTypeDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdIngredientType", ingredientTypeDTO.IdIngredientType);
            parameters.Add("@Type", ingredientTypeDTO.IngredientType);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateIngredientType", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Success");
            }
        }
    }
}
