using RecipeMicroService.DBContexts;
using RecipeMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroService.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _dbContext;
        public RecipeRepository(RecipeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Recipe GetRecipeByID(int RecipeId)
        {
            return _dbContext.Recipes.Find(RecipeId);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _dbContext.Recipes.ToList();
        }
    }
}
