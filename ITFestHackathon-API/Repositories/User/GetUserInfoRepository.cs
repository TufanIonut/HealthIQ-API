using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Responses;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;

namespace HealthIQ.Repositories.User
{
    public class GetUserInfoRepository : IGetUserInfoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetUserInfoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<GetUserInfoResponse>> GetUserInfoAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var userInfo = await connection.QueryAsync<GetUserInfoResponse>("GetUserInfo", parameters, commandType: CommandType.StoredProcedure);

                return userInfo;
            }
        }
        
    }
}
