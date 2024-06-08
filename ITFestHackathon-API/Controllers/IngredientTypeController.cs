using HealthIQ.DTOs;
using HealthIQ.DTOs.Update;
using HealthIQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientTypeController : ControllerBase
    {
        private readonly IGetIngredientTypesRepository _ingredientTypeRepository;
        private readonly IDeleteIngredientTypeRepository _deleteIngredientTypeRepository;
        private readonly IAddIngredientTypeRepository _addIngredientTypeRepository;
        private readonly IUpdateIngredientTypeRepository _updateIngredientTypeRepository;
        public IngredientTypeController(IGetIngredientTypesRepository ingredientTypeRepository, IDeleteIngredientTypeRepository deleteIngredientTypeRepository, 
            IAddIngredientTypeRepository insertIngredientTypeRepository, IUpdateIngredientTypeRepository updateIngredientTypeRepository)
        {
            _ingredientTypeRepository = ingredientTypeRepository;
            _deleteIngredientTypeRepository = deleteIngredientTypeRepository;
            _addIngredientTypeRepository = insertIngredientTypeRepository;
            _updateIngredientTypeRepository = updateIngredientTypeRepository;
        }

        [HttpGet]
        [Route("GetIngredientTypes")]
        public async Task<IActionResult> GetIngredientTypesAsync()
        {
            var ingredientTypes = await _ingredientTypeRepository.GetIngredientTypesAsyncRepo();
            return Ok(ingredientTypes);
        }
        [HttpDelete]
        [Route("DeleteIngredientType")]
        public async Task<IActionResult> DeleteIngredientTypeAsync([FromBody] int TypeId)
        {
            var success = await _deleteIngredientTypeRepository.DeleteIngredientTypeAsyncRepo(TypeId);
            if (success == 1)
            {
                return Ok(success);
            }
            else
            {
                return BadRequest("Delete failed");
            }
        }
        [HttpPost]
        [Route("AddIngredientType")]
        public async Task<IActionResult> AddIngredientTypeAsync([FromBody] IngredientTypeDTO ingredientTypeDTO)
        {
            var success = await _addIngredientTypeRepository.AddIngredientTypeAsyncRepo(ingredientTypeDTO);
            if (success == 1)
            {
                return Ok(success);
            }
            else
            {
                return BadRequest("Insert failed");
            }
        }

        [HttpPatch]
        [Route("UpdateIngredientType")]
        public async Task<IActionResult> UpdateIngredientTypeAsync([FromBody] UpdateIngredientTypeDTO ingredientTypeDTO)
        {
            var success = await _updateIngredientTypeRepository.UpdateIngredientTypeAsyncRepo(ingredientTypeDTO);
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
