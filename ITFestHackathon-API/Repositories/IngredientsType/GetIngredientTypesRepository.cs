using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories.IngredientsType
{
    public class GetIngredientTypesRepository : IGetIngredientTypesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetIngredientTypesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetIngredientTypeResponse>> GetIngredientTypesAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var ingredientTypes = await connection.QueryAsync<GetIngredientTypeResponse>("GetIngredientTypes", commandType: CommandType.StoredProcedure);
                return ingredientTypes;
            }
        }
    }
}
