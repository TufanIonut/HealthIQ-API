using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ExerciseController : ControllerBase
    {
        private readonly IGetExercisesWithMusclesRepository _getExercisesWithMusclesRepository;

        public ExerciseController(IGetExercisesWithMusclesRepository getExercisesWithMusclesRepository)
        {
            _getExercisesWithMusclesRepository = getExercisesWithMusclesRepository;
        }

        [HttpGet]
        [Route("GetExercisesJoinMuscles")]
        public async Task<IActionResult> GetExercise()
        {
            var result = await _getExercisesWithMusclesRepository.GetExercisesWithMusclesAsyncRepo();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
