using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using HealthIQ.Responses;

namespace HealthIQ.Repositories.Advice
{
    public class GetAdvicesRepository : IGetAdvicesRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetAdvicesRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<GetAdviceResponse>> GetAdvicesAsyncRepo()
        {
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var advices = await connection.QueryAsync<GetAdviceResponse>("GetAdvices", commandType: CommandType.StoredProcedure);
                return advices;
            }
        }
    }
}
