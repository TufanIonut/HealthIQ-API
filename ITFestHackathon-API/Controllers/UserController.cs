using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IRegisterUserRepository _registerUserRepository;
        private readonly ILoginUserRepository _loginUserRepository;
        private readonly IInsertUserInformationRepository _insertUserInformationRepository;
        private readonly IUpdateUserPointsRepository _updateUserPointsRepository;
        private readonly IGetCalorieIntakeRepository _getCalorieIntakeRepository;
        private readonly IGetUserInfoRepository _getUserInfoRepository;
        private readonly IGetUserWeightsRepository _getUserWeightsRepository;

        public UserController(IRegisterUserRepository registerUserRepository, ILoginUserRepository loginUserRepository,
            IInsertUserInformationRepository insertUserInformationRepository, IUpdateUserPointsRepository updateUserPointsRepository,
            IGetCalorieIntakeRepository getCalorieIntakeRepository, IGetUserInfoRepository getUserInfoRepository, IGetUserWeightsRepository getUserWeightsRepository)
        {
            _registerUserRepository = registerUserRepository;
            _loginUserRepository = loginUserRepository;
            _insertUserInformationRepository = insertUserInformationRepository;
            _updateUserPointsRepository = updateUserPointsRepository;
            _getCalorieIntakeRepository = getCalorieIntakeRepository;
            _getUserInfoRepository = getUserInfoRepository;
            _getUserWeightsRepository = getUserWeightsRepository;
        }

        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(int idUser)
        {
            var result = await _getUserInfoRepository.GetUserInfoAsyncRepo(idUser);

            if (result == null)
                return BadRequest();

            return Ok(result);
        } 

        [HttpGet]
        [Route("GetRecommendedCalorieIntake")]
        public async Task<IActionResult> GetRecommendedCalorieIntake(int userId)
        {
            var result = await _getCalorieIntakeRepository.GetCalorieIntakeAsyncRepo(userId);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            var userID = await _registerUserRepository.RegisterUserAsyncRepo(userCredentialsDTO);
            if (userID != -1)
            {
                return Ok(userID);
            }else
            {
                return BadRequest("User exists already");
            }
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUserAsync([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            var userID = await _loginUserRepository.LoginUserAsyncRepo(userCredentialsDTO);
            switch(userID)
            {
                case 0:
                    return Ok(userID);
                case -1:
                    return BadRequest("Login failed");
                default:
                    return Ok(userID);
            }
        }

        [HttpPatch]
        [Route("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfoAsync([FromBody] UserInformationDTO userInformationDTO)
        {
            var success = await _insertUserInformationRepository.InsertUserInformationAsyncRepo(userInformationDTO);
            if(success == 1)
            {
                return Ok(success);
            }
            else
            {
                return BadRequest("Update failed");
            }
        }

        [HttpPatch]
        [Route("UpdateUserPoints")]
        public async Task<IActionResult> UpdateUserPointsAsync([FromBody] UpdateUserPointsDTO userPointsDTO)
        {
            var success = await _updateUserPointsRepository.UpdateUserPointsAsyncRepo(userPointsDTO);
            if (success == 1)
            {
                return Ok(success);
            }
            else
            {
                return BadRequest("Update failed");
            }
        }
        [HttpGet]
        [Route("GetUserWeights")]
        public async Task<IActionResult> GetUserWeights(int idUser)
        {
            var result = await _getUserWeightsRepository.GetUserWeightsAsyncRepo(idUser);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
