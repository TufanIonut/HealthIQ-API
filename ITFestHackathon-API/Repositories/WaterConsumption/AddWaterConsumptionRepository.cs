using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.WaterConsumption
{
    public class AddWaterConsumptionRepository : IAddWaterConsumptionRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddWaterConsumptionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> AddWaterConsumptionAsyncRepo(WaterConsumptionDTO waterConsumptionDTO)
        {
            string Date = waterConsumptionDTO.Date.ToString("yyyy-MM-dd");
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", waterConsumptionDTO.IdUser);
            parameters.Add("@WaterGlasses", waterConsumptionDTO.WaterGlasses);
            parameters.Add("@Date", Date);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertWaterConsumption", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
