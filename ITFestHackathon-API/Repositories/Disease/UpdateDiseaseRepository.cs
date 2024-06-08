
using Dapper;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Disease
{
    public class UpdateDiseaseRepository : IUpdateDiseaseRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UpdateDiseaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> UpdateDiseaseAsyncRepo(UpdateDiseaseDTO disease)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdDisease", disease.IdDisease);
            parameters.Add("@NewDiseaseName", disease.DiseaseName);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                 await connection.ExecuteAsync("UpdateDisease",parameters,commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");

                return result;
            }
        }
    }
}
