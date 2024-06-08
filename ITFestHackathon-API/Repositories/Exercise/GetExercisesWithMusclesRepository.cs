using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories.Exercise
{
    public class GetExercisesWithMusclesRepository : IGetExercisesWithMusclesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetExercisesWithMusclesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<ExerciseWithMusclesDTO>> GetExercisesWithMusclesAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var exercisesWithMuscles = await connection.QueryAsync<ExerciseWithMusclesDTO>("GetExercisesWithMuscles", commandType: CommandType.StoredProcedure);
                return exercisesWithMuscles;
            }
        }
    }
}
