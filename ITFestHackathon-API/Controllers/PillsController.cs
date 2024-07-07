using HealthIQ.DTOs;
using HealthIQ.Repositories;
using HealthIQ.Requests;
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
        public async Task<IEnumerable<MedsResponse>> GetMeds()
        {
            return await _supplementsRepository.GetMeds();
        }
        [HttpDelete]
        [Route("DeleteMeds")]
        public async Task<IActionResult> DeleteMeds(int id)
        {
            var result = await _supplementsRepository.DeleteMeds(id);
            if (result == 1)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPatch]
        [Route("ToogleTaken")]
        public async Task<IActionResult> ToogleTaken(int id)
        {
            var result = await _supplementsRepository.ToogleTaken(id);
            if (result == 1)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetManufacturers")]
        public async Task<IEnumerable<ManufacturerResponse>> GetManufacturers()
        {
            return await _supplementsRepository.GetManufacturers();
        }
        [HttpPost]
        [Route("InsertPill")]
        public async Task<IActionResult> InsertPillAsync(AddPillRequest addPillRequest)
        {
            var result = await _supplementsRepository.InsertPillAsync(addPillRequest);
            if (result == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
