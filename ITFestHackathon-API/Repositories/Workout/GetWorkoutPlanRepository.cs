using System.Data;
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;

namespace HealthIQ.Repositories.Workout
{
    public class GetWorkoutPlanRepository : IGetWorkoutPlanRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetWorkoutPlanRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<WorkoutPlanDTO>> GetWorkputPlanAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters(idUser);
            parameters.Add("@IdUser", idUser);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var personalizedWorkouts = await connection.QueryAsync<WorkoutPlanDTO>("GetPersonalizedWorkouts", parameters,commandType: CommandType.StoredProcedure);
                return personalizedWorkouts;
            }
        }
    }
}
