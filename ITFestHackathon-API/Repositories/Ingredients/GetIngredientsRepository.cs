using System.Data;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Repositories.Ingredients
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
