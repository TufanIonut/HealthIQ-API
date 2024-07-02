using System.Data;
using System.Text;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Security.Cryptography;

namespace HealthIQ.Repositories.User
{
    public class LoginUserRepository : ILoginUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public LoginUserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> LoginUserAsyncRepo(UserCredentialsDTO userCredentialsDTO)
        {
            var parameters = new DynamicParameters();
            var hashedPassword = HashPassword(userCredentialsDTO.Password);
            parameters.Add("@Email", userCredentialsDTO.Email);
            parameters.Add("@Password", hashedPassword);
            parameters.Add("@UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("LoginUser", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("UserID");
            }
        }
        public async Task<int> ChangePassword(UserCredentialsDTO userCredentials)
        {
            var parameters = new DynamicParameters();
            var hashedPassword = HashPassword(userCredentials.Password);
            parameters.Add("@Email", userCredentials.Email);
            parameters.Add("@NewPassword", hashedPassword);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("ResetPassword", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Success");
            }
        }
        private string HashPassword(string pasword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pasword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
