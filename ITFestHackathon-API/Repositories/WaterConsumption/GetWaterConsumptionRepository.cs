using System.Data;
using System.Linq.Expressions;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;

namespace ITFestHackathon_API.Repositories.WaterConsumption
{
    public class GetWaterConsumptionRepository : IGetWaterConsumptionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetWaterConsumptionRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<GetWaterConsumptionResponse>> GetWaterConsumptionAsyncRepo(int IdUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", IdUser);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var waterConsumption = await connection.QueryAsync<GetWaterConsumptionResponse>("GetWaterConsumption",parameters, commandType: CommandType.StoredProcedure);
                return waterConsumption;
            }
        }
    }
}
