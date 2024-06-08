using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;


namespace HealthIQ.Repositories.User
{
    public class UpdateUserPointsRepository : IUpdateUserPointsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UpdateUserPointsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> UpdateUserPointsAsyncRepo(UpdateUserPointsDTO userPointsDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", userPointsDTO.UserID);
            parameters.Add("@Points", userPointsDTO.Points);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateUserPoints", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
