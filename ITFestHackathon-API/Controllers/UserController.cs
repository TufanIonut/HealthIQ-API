using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IRegisterUserRepository _registerUserRepository;
        private readonly ILoginUserRepository _loginUserRepository;
        private readonly IInsertUserInformationRepository _insertUserInformationRepository;
        private readonly IUpdateUserPointsRepository _updateUserPointsRepository;
        public UserController(IRegisterUserRepository registerUserRepository, ILoginUserRepository loginUserRepository,
            IInsertUserInformationRepository insertUserInformationRepository, IUpdateUserPointsRepository updateUserPointsRepository)
        {
            _registerUserRepository = registerUserRepository;
            _loginUserRepository = loginUserRepository;
            _insertUserInformationRepository = insertUserInformationRepository;
            _updateUserPointsRepository = updateUserPointsRepository;
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
                    return Ok(userID + " Admin");
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
    }
}
