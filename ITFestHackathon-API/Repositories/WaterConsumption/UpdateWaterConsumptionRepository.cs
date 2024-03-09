using Dapper;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.WaterConsumption
{
    public class UpdateWaterConsumptionRepository : IUpdateWaterConsumptionRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UpdateWaterConsumptionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> UpdateWaterConsumptionAsyncRepo(UpdateWaterConsumptionDTO waterConsumption)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", waterConsumption.IdUser);
            parameters.Add("@Date", waterConsumption.Date);
            parameters.Add("@WaterGlasses", waterConsumption.WaterGlasses);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateWaterConsumption", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");

                return result;
            }
        }
    }
}