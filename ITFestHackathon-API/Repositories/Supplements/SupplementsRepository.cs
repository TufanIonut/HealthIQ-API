
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories
{
    public class SupplementsRepository : ISupplementsRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;
        public SupplementsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<PillsResponse>> GetPills()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<PillsResponse>("GetPills",  commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<bool> insertMeds(MedsDTO meds)
        {
             
        var parameters = new DynamicParameters();
            parameters.Add("@IdUser", meds.IdUser);
            parameters.Add("@PillName", meds.PillName);
            parameters.Add("@TakingHour", meds.TakingHour);
            parameters.Add("@TimesPerDay", meds.TimesPerDay);
            parameters.Add("@Taken", meds.Taken);
            parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertMedication", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<bool>("Success");
                return result;
            }
        }
        public async Task<IEnumerable<MedsDTO>> GetMeds()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<MedsDTO>("GetMedication", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
