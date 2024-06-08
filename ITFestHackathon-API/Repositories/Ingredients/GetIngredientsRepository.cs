using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Responses;

namespace HealthIQ.Repositories.Ingredients
{
    public class GetIngredientsRepository : IGetIngredientsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetIngredientsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<GetIngredientResponse>> GetIngredientsAsyncRepo()
        {
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var ingredients = await connection.QueryAsync<GetIngredientResponse>("GetIngredients", commandType: CommandType.StoredProcedure);
                return ingredients;
            }
        }
    }
}
