using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using HealthIQ.Requests;
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
        [HttpGet]
        [Route("GetMuscleGroups")]
        public async Task<IActionResult> GetMuscleGroups()
        {
            var result = await _getExercisesWithMusclesRepository.GetMuscleGroupsAsyncRepo();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        [Route("AddExercise")]
        public async Task<IActionResult> AddExercise(AddExerciseRequest addExerciseRequest)
        {
            var result = await _getExercisesWithMusclesRepository.AddExerciseAsyncRepo(addExerciseRequest);

            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}
