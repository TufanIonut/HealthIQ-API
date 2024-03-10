using ITFestHackathon_API.DTOs;
using ITFestHackathon_API.DTOs.Update;
using ITFestHackathon_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITFestHackathon_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecipeIngredientsController : ControllerBase
    {
        private readonly IGetRecipeIngredientsRepository _getRecipeIngredientsRepository;


        public RecipeIngredientsController(IGetRecipeIngredientsRepository getRecipeIngredientsRepository)
        {
            _getRecipeIngredientsRepository = getRecipeIngredientsRepository;
        }

        [HttpGet]
        [Route("GetRecipeJoinIngredients")]
        public async Task<IActionResult> GetIngredients()
        {
            var result = await _getRecipeIngredientsRepository.GetRecipeIngredientsAsyncRepo();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }


}
