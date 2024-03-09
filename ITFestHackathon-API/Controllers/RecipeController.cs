using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecipeController : ControllerBase
    {
        private readonly IGetRecipeRepository _getRecipeRepository;
        private readonly IDeleteRecipeRepository _deleteRecipeRepository;
        private readonly IAddRecipeRepository _addRecipeRepository;
        private readonly IUpdateRecipeRepository _updateRecipeRepository;

        public RecipeController(IGetRecipeRepository getRecipeRepository,
            IDeleteRecipeRepository deleteRecipeRepository,
            IAddRecipeRepository addRecipeRepository, IUpdateRecipeRepository updateRecipeRepository)
        {
            _getRecipeRepository = getRecipeRepository;
            _deleteRecipeRepository = deleteRecipeRepository;
            _addRecipeRepository = addRecipeRepository;
            _updateRecipeRepository = updateRecipeRepository;
        }

        [HttpGet]
        [Route("GetRecipes")]
        public async Task<IActionResult> GetRecipes()
        {
            var result = await _getRecipeRepository.GetRecipesAsyncRepo();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteRecipe")]
        public async Task<IActionResult> DeleteRecipeAsync([FromBody] int RecipeId)
        {
            var success = await _deleteRecipeRepository.DeleteRecipeAsyncRepo(RecipeId);
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
        [Route("AddRecipe")]
        public async Task<IActionResult> AddRecipe( RecipeDTO recipeDTO)
        {
            var result = await _addRecipeRepository.AddRecipeAsyncRepo(recipeDTO);

            if (result == 0)
                return BadRequest();

            return Ok(result);
        }

        [HttpPatch]
        [Route("UpdateRecipe")]
        public async Task<IActionResult> UpdateRecipeAsync([FromBody] UpdateRecipeDTO updateRecipeDTO)
        {
            var success = await _updateRecipeRepository.UpdateRecipeAsyncRepo(updateRecipeDTO);
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
