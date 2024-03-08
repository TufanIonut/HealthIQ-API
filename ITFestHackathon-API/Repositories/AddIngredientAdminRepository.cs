using System.Data;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;

namespace ITFestHackathon_API.Repositories
{
    public class AddIngredientAdminRepository : IAddIngredientAdminRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        
        public AddIngredientAdminRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //public async Task<int> AddIngredientAdminAsyncRepo(IngredientDTO ingredientDTO)
        //{
        //    var parameters = new DynamicParameters();

        //    parameters.Add("")
        //}
    }
}
