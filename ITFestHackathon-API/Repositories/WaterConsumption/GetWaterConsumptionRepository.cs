using System.Data;
using System.Linq.Expressions;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using HealthIQ.Responses;

namespace HealthIQ.Repositories.WaterConsumption
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
