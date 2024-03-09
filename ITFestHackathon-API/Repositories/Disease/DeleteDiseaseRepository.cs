using Dapper;
using ITFestHackathon_API.Interfaces;
using System.Data;

namespace ITFestHackathon_API.Repositories.Diseases
{
    public class DeleteDiseaseRepository : IDeleteDiseaseRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public DeleteDiseaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> DeleteDiseaseAsyncRepo(int DiseaseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdDisease", DiseaseId);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteDisease", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}