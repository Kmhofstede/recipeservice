using Microsoft.AspNetCore.Mvc;
using RecipeMicroService.Models;
using RecipeMicroService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        // GET: api/<RecipeController>
        [HttpGet]
        public IActionResult Get()
        {
            var recipes = _recipeRepository.GetRecipes();
            return new OkObjectResult(recipes);
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = _recipeRepository.GetRecipeByID(id);
            return new OkObjectResult(recipe);
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            using (var scope = new TransactionScope())
            {
                _recipeRepository.InsertRecipe(recipe);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Recipe recipe)
        {
            if (recipe != null)
            {
                using (var scope = new TransactionScope())
                {
                    _recipeRepository.UpdateRecipe(recipe);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recipeRepository.DeleteRecipe(id);
            return new OkResult();
        }
    }
}
