using System.Data;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;

namespace ITFestHackathon_API.Repositories.CalorieIntake
{
    public class GetCalorieIntakeRepository : IGetCalorieIntakeRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetCalorieIntakeRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<RecommendedCalorieIntakeDTO>> GetCalorieIntakeAsyncRepo(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("IdUser", userId);
            
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var calorieIntake = await connection.QueryAsync<RecommendedCalorieIntakeDTO>("CalculateCalories", parameters, commandType: CommandType.StoredProcedure);
                return calorieIntake;
            }
        }
    }
}
