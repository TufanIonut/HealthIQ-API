using System.Data;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Repositories.RecipeIngredients
{
    public class GetRecipeIngredientsRepository : IGetRecipeIngredientsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetRecipeIngredientsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipeIngredientsAsyncRepo()
        {
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var recipeIngredients = await connection.QueryAsync<RecipesJoinIngredientsDTO>("GetRecipesWithIngredients", commandType: CommandType.StoredProcedure);
                return recipeIngredients;
            }
        }
    }
}
