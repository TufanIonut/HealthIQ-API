using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
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
