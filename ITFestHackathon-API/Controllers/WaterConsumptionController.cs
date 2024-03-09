using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WaterConsumptionController : ControllerBase
    {
        private readonly IGetWaterConsumptionRepository _getWaterConsumptionRepository;
        private readonly IUpdateWaterConsumptionRepository _updateWaterConsumptionRepository;

        public WaterConsumptionController(IGetWaterConsumptionRepository getWaterConsumptionRepository, IUpdateWaterConsumptionRepository updateWaterConsumptionRepository)
        {
            _getWaterConsumptionRepository = getWaterConsumptionRepository;
            _updateWaterConsumptionRepository = updateWaterConsumptionRepository; 
        }

        [HttpGet]
        [Route("GetWaterConsumption/{IdUser}")]
        public async Task<IActionResult> GetWaterConsumption(int IdUser)
        {
            var result = await _getWaterConsumptionRepository.GetWaterConsumptionAsyncRepo(IdUser);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPatch]
        [Route("UpdateWaterConsumption")]
        public async Task<IActionResult> UpdateWaterConsumptionAsync([FromBody] UpdateWaterConsumptionDTO waterConsumptionDTO)
        {
            var success = await _updateWaterConsumptionRepository.UpdateWaterConsumptionAsyncRepo(waterConsumptionDTO);
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