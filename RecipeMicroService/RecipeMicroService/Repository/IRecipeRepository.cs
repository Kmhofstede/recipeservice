using RecipeMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroService.Repository
{
    interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeByID(int RecipeId);

    }
}
