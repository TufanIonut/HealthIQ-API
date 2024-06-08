

using Dapper;
using HealthIQ.Interfaces;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories.User
{
    public class GetUserWeightsRepository : IGetUserWeightsRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public GetUserWeightsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<UserWeightResponse>> GetUserWeightsAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserId", idUser);
            using (var connection = dbConnectionFactory.ConnectToDataBase())
            {
                var response = await connection.QueryAsync<UserWeightResponse>("GetUserWeight", parameters, commandType: CommandType.StoredProcedure);
                return response;
            }
        }
    }
}
