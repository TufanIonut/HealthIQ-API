using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Requests;
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
        public async Task<IEnumerable<MuscleGroupsResponse>> GetMuscleGroupsAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var muscleGroups = await connection.QueryAsync<MuscleGroupsResponse>("GetMuscleGroups", commandType: CommandType.StoredProcedure);
                return muscleGroups;
            }
        }
        public async Task<int> AddExerciseAsyncRepo(AddExerciseRequest addExerciseRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ExerciseName", addExerciseRequest.ExerciseName);
            parameters.Add("@DifficultyLevel", addExerciseRequest.DifficultyLevel);
            parameters.Add("@ExerciseLink", addExerciseRequest.ExerciseLink);
            parameters.Add("@MuscleGroupName", addExerciseRequest.MuscleGroupName);
            parameters.Add("@MuscleGroupSecondary", addExerciseRequest.MuscleGroupSecondary);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("AddExercise", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
