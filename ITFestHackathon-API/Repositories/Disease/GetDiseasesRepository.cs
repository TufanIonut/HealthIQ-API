using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;

namespace HealthIQ.Repositories.Disease
{
    public class GetDiseasesRepository : IGetDiseasesRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetDiseasesRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<UpdateDiseaseDTO>> GetDiseasesAsyncRepo()
        {
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var diseases = await connection.QueryAsync<UpdateDiseaseDTO>("GetDiseases", commandType: CommandType.StoredProcedure);
                return diseases;
            }
        }
    }
}
