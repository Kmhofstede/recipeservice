using Microsoft.EntityFrameworkCore;
using RecipeMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroService.DBContexts
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
          new Recipe
          {
              Id = 1,
              Name = "Boboti",
              Description = "iets met boontjes",
          },
          new Recipe
          {
              Id = 2,
              Name = "Boerenkool",
              Description = "ouderwets hollands",
          },
          new Recipe
          {
              Id = 3,
              Name = "Schnitzel",
              Description = "Gewoon simpel",
          }
      );
        }
    }
}
