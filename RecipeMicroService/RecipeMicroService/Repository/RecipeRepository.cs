using Microsoft.EntityFrameworkCore;
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

        public void DeleteRecipe(int RecipeId)
        {
            var product = _dbContext.Recipes.Find(RecipeId);
            _dbContext.Recipes.Remove(product);
            Save();
        }

        

        public void InsertRecipe(Recipe recipe)
        {
            _dbContext.Add(recipe);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _dbContext.Entry(recipe).State = EntityState.Modified;
            Save();
        }
    }
}
