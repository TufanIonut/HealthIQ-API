using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using System.Data;


namespace HealthIQ.Repositories.User
{
    public class InsertUserInformationRepository : IInsertUserInformationRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public InsertUserInformationRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> InsertUserInformationAsyncRepo(UserInformationDTO userInformationDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", userInformationDTO.UserID);
            parameters.Add("@FirstName", userInformationDTO.FirstName);
            parameters.Add("@LastName", userInformationDTO.LastName);
            parameters.Add("@BirthDate", userInformationDTO.BirthDate);
            parameters.Add("@Weight", userInformationDTO.Weight);
            parameters.Add("@Height", userInformationDTO.Height);
            parameters.Add("@FitLevel", userInformationDTO.FitLevel);
            parameters.Add("@TrainingFrequency", userInformationDTO.TrainingFrequency);
            parameters.Add("@UserTarget", userInformationDTO.UserTarget);
            parameters.Add("@Gender", userInformationDTO.Gender);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertUserInformation", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
