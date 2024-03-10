using System.Data;
using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;

namespace ITFestHackathon_API.Repositories.Workout
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
