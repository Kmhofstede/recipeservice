using RecipeMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroService.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        public Recipe GetRecipeByID(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
