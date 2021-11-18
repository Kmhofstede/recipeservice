using RecipeMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroService.Repository
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeByID(int RecipeId);
        public void DeleteRecipe(int RecipeId);
        public void InsertRecipe(Recipe recipe);
        public void Save();
        public void UpdateRecipe(Recipe recipe);
    }
}
