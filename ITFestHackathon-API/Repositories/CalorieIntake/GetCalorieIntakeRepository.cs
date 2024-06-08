using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;

namespace HealthIQ.Repositories.CalorieIntake
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
