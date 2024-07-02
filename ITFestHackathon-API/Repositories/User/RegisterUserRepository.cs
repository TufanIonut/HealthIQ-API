using System.Data;
using System.Security.Cryptography;
using System.Text;
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
                userCredentialsDTO.Password = HashPassword(userCredentialsDTO.Password);
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
