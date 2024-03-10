using Dapper;
using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Responses;
using System.Data;

namespace ITFestHackathon_API.Repositories.Exercise
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
