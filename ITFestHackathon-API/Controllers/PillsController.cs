using HealthIQ.Repositories;
using HealthIQ.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PillsController : ControllerBase
    {
        private readonly ISupplementsRepository _supplementsRepository;

        public PillsController(ISupplementsRepository supplementsRepository)
        {
            _supplementsRepository = supplementsRepository;
        }

        [HttpGet]
        [Route("GetPills")]
        public async Task<IEnumerable<PillsResponse>> GetPills()
        {
            return await _supplementsRepository.GetPills();
        }

        [HttpPost]
        [Route("AddMeds")]

       public async Task<IActionResult> AddMeds(MedsDTO pillsResponse)
        {
            var result = await _supplementsRepository.insertMeds(pillsResponse);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetMeds")]
        public async Task<IEnumerable<MedsDTO>> GetMeds()
        {
            return await _supplementsRepository.GetMeds();
        }

    }
}
