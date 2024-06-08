using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;

namespace HealthIQ.Repositories.Disease
{
    public class AddDiseaseRepository : IAddDiseaseRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddDiseaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> AddDiseaseAsyncRepo(DiseaseDTO disease)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@diseaseName", disease.DiseaseName);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertDisease",parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
