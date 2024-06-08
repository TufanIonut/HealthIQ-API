using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WaterConsumptionController : ControllerBase
    {
        private readonly IGetWaterConsumptionRepository _getWaterConsumptionRepository;
        private readonly IUpdateWaterConsumptionRepository _updateWaterConsumptionRepository;
        private readonly IAddWaterConsumptionRepository _addWaterConsumptionRepository;

        public WaterConsumptionController(IGetWaterConsumptionRepository getWaterConsumptionRepository,
            IUpdateWaterConsumptionRepository updateWaterConsumptionRepository, 
            IAddWaterConsumptionRepository addWaterConsumptionRepository)
        {
            _getWaterConsumptionRepository = getWaterConsumptionRepository;
            _updateWaterConsumptionRepository = updateWaterConsumptionRepository;
            _addWaterConsumptionRepository = addWaterConsumptionRepository;
        }

        [HttpPost]
        [Route("AddWaterConsumption")]
        public async Task<IActionResult> AddRecipe(WaterConsumptionDTO waterConsumptionDTO)
        {
            var result = await _addWaterConsumptionRepository.AddWaterConsumptionAsyncRepo(waterConsumptionDTO);

            if (result == 0)
                return BadRequest();

            return Ok(result);
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