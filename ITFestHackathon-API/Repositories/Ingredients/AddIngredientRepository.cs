using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;

namespace HealthIQ.Repositories.Ingredients
{
    public class AddIngredientRepository : IAddIngredientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AddIngredientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddIngredientAsyncRepo(IngredientDTO ingredientDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IngredientName", ingredientDTO.IngredientName);
            parameters.Add("@IngredientType", ingredientDTO.IngredientType);
            parameters.Add("@CaloriesNOPer100g", ingredientDTO.CaloriesNOPer100g);
            parameters.Add("@ProteinNoPer100g", ingredientDTO.ProteinNoPer100g);
            parameters.Add("@CarboNoPer100g", ingredientDTO.CarboNoPer100g);
            parameters.Add("@FatsNoPer100g", ingredientDTO.FatsNoPer100g);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertIngredient", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Success");
            }
        }
    }
}
