using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class IngredientController : ControllerBase
    {
        private readonly IGetIngredientsRepository _getIngredientsRepository;
        private readonly IAddIngredientRepository _addIngredientRepository;
        private readonly IDeleteIngredientRepository _deleteIngredientRepository;
        private readonly IUpdateIngredientRepository _updateIngredientRepository;
        public IngredientController(IGetIngredientsRepository getIngredientsRepository,IAddIngredientRepository addIngredientRepository,
            IDeleteIngredientRepository deleteIngredientRepository, IUpdateIngredientRepository updateIngredientRepository)
        {
            _getIngredientsRepository = getIngredientsRepository;
            _addIngredientRepository = addIngredientRepository;
            _deleteIngredientRepository = deleteIngredientRepository;
            _updateIngredientRepository = updateIngredientRepository;
        }

        [HttpGet]
        [Route("GetIngredients")]
        public async Task<IActionResult> GetIngredients()
        {
            var result = await _getIngredientsRepository.GetIngredientsAsyncRepo();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddIngredient")]
        public async Task<IActionResult> AddIngredient([FromBody] IngredientDTO ingredientDTO)
        {
            var result = await _addIngredientRepository.AddIngredientAsyncRepo(ingredientDTO);

            if (result == 0)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteIngredient")]
        public async Task<IActionResult> DeleteIngredientAsync([FromBody] int IngredientId)
        {
            var success = await _deleteIngredientRepository.DeleteIngredientAsyncRepo(IngredientId);
            if (success == 1)
            {
                return Ok(success);
            }
            else
            {
                return BadRequest("Delete failed");
            }
        }
        [HttpPatch]
        [Route("UpdateIngredient")]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredientDTO ingredientDTO)
        {
            var success = await _updateIngredientRepository.UpdateIngredientAsyncRepo(ingredientDTO);
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
