using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WorkoutPlanController : ControllerBase
    {
        private readonly IGetWorkoutPlanRepository _getWorkoutPlanRepository;

        public WorkoutPlanController(IGetWorkoutPlanRepository getWorkoutPlanRepository)
        {
            _getWorkoutPlanRepository = getWorkoutPlanRepository;
        }

        [HttpGet]
        [Route("GetWorkoutPlan")]
        public async Task<IActionResult> GetExercise(int idUser)
        {
            var result = await _getWorkoutPlanRepository.GetWorkputPlanAsyncRepo(idUser);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
