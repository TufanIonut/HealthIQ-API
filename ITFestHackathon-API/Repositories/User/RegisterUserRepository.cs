using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;

namespace HealthIQ.Repositories.User
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public RegisterUserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> RegisterUserAsyncRepo(UserCredentialsDTO userCredentialsDTO)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", userCredentialsDTO.Email);
                parameters.Add("@Password", userCredentialsDTO.Password);
                parameters.Add("UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("RegisterUser", parameters, commandType: CommandType.StoredProcedure);
                    return parameters.Get<int>("UserID");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
