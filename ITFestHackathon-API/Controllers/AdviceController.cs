using ITFestHackathon_API.Responses;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AdviceController : ControllerBase
    {
        private readonly IGetAdvicesRepository _getAdvicesRepository;

        public AdviceController(IGetAdvicesRepository getAdvicesRepository)
        {
            _getAdvicesRepository = getAdvicesRepository;
        }

        [HttpGet]
        [Route("GetAdvices")]
        public async Task<IActionResult> GetAdvices()
        {
            var result = await _getAdvicesRepository.GetAdvicesAsyncRepo();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}