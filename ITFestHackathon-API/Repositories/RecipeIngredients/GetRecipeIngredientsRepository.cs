using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Responses;

namespace HealthIQ.Repositories.RecipeIngredients
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
        public async Task<IEnumerable<RecipesJoinIngredientsDTO>> GetRecipeIngredientsForUserAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            using (var connect = _connectionFactory.ConnectToDataBase())
            {
                var recipeIngredients = await connect.QueryAsync<RecipesJoinIngredientsDTO>("GetRecipesWithIngredientsForUser", parameters, commandType: CommandType.StoredProcedure);
                return recipeIngredients;
            }
        }
    }
}
