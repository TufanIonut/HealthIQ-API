using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneticController : ControllerBase
    {
        private readonly IGeneticService _geneticService;

        public GeneticController(IGeneticService geneticService)
        {
            _geneticService = geneticService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_geneticService.GenerateWorkoutPlan());
        }

    }
}
