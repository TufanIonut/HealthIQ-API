using System.Data;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Repositories.Advice
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
