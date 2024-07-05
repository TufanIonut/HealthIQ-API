using Dapper;
using HealthIQ.Interfaces;
using HealthIQ.Requests;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories.Reviews
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ReviewsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> AddReviewAsync(AddReviewRequest addReviewRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addReviewRequest.IdUser);
            parameters.Add("@Review", addReviewRequest.Review);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                return await connection.ExecuteAsync("AddReview", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ReviewsResponse>> GetReviewsAsync()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                return await connection.QueryAsync<ReviewsResponse>("GetReviews", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<UserReviewRespose>> GetUserReviewsAsync(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                return await connection.QueryAsync<UserReviewRespose>("GetUserReviews", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<int> DeleteReview (int idReview)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@@IdUserReview", idReview);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
               await connection.ExecuteAsync("DeleteReview", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("@Success");
                return result;
            }
        }
    }
}
