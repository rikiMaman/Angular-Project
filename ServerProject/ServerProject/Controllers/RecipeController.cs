using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ServerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public static int recipeCode=9;
        public static List<Recipe> recipeList = new List<Recipe>()
        {
            new Recipe(){ RecipeCode=1, RecipeName="CheeseCake", CategoryCode=1,PreparationTimeMinutes=50, DifficultyLevel=3, DateAdded=new DateTime(),
                Ingredients=["water","Milk", "Oil", "Flour"], PreparationSteps=["Beat the egg whites with the sugar", "Bake in the oven"], UserCode=111, ImageRoute= "assets\\10.jpg" },
            new Recipe(){ RecipeCode=2, RecipeName="Ice-Cream", CategoryCode=3,PreparationTimeMinutes=45, DifficultyLevel=5, DateAdded=new DateTime(),
                Ingredients=["Milk", "Sugar","SoftIceCream"], PreparationSteps=["Beat the egg whites with the sugar", "Grind all the fruities"], UserCode=111, ImageRoute= "assets\\46.jpg" },
            new Recipe(){ RecipeCode=3, RecipeName="Petipur", CategoryCode=1,PreparationTimeMinutes=35, DifficultyLevel=4, DateAdded=new DateTime(),
                Ingredients=["Milk", "Sugar"], PreparationSteps=["melt the chocolate", "Add Chokolate"], UserCode=111, ImageRoute= "assets\\12.jpg" },
            new Recipe(){ RecipeCode=4, RecipeName="Birthday Cake", CategoryCode=2,PreparationTimeMinutes=200, DifficultyLevel=3, DateAdded=new DateTime(),
                Ingredients=["water","Flour","Oil"], PreparationSteps=["Beat the egg whites with the sugar", "Bake in the oven"], UserCode=111, ImageRoute= "assets\\7.jpg" },
            new Recipe(){ RecipeCode=6, RecipeName="Milk Shake", CategoryCode=1,PreparationTimeMinutes=120, DifficultyLevel=3, DateAdded=new DateTime(),
                Ingredients=["water","Milk"], PreparationSteps=["Grind all the fruities", "Add milk"], UserCode=1, ImageRoute= "assets\\44.jpg" },
            new Recipe(){ RecipeCode=7, RecipeName="Cookies", CategoryCode=2,PreparationTimeMinutes=15, DifficultyLevel=1, DateAdded=new DateTime(),
                Ingredients=["water","Flour"], PreparationSteps=["Bake in the oven", "melt the chocolate"], UserCode=111, ImageRoute= "assets\\40.jpg" },
            new Recipe(){ RecipeCode=8, RecipeName="pancake", CategoryCode=3,PreparationTimeMinutes=180, DifficultyLevel=5, DateAdded=new DateTime(),
                Ingredients=["water","Flour"], PreparationSteps=["Mix flour, eggs and milk","Fry the mixture in a pan", "melt the chocolate"], UserCode=111, ImageRoute="assets\\vertical-view-vegan-tofu-pancakes-with-fruits-white-plate.jpg" }

        };
        //Get all recipe
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return recipeList;
        }
        //Get by id
        //[HttpGet("{id}")]
        //public Recipe Get(int id) 
        //{
        //    var recipe = recipeList[id-1];
        //    return recipe;
        //}
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe) 
        {
            try
            {
                recipe.RecipeCode = recipeCode++;
                recipeList.Add(recipe);
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingRecipe = recipeList.FirstOrDefault(r => r.RecipeCode == id);
                if (existingRecipe == null)
                {
                    return NotFound();
                }
                recipeList.Remove(existingRecipe);
                return Ok(existingRecipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Recipe updatedRecipe)
        {
            try
            {
                var existingRecipe = recipeList.FirstOrDefault(r => r.RecipeCode == id);
                if (existingRecipe == null)
                {
                    return NotFound();
                }

                // Update the existing recipe with the properties from the updatedRecipe object
                existingRecipe.RecipeName = updatedRecipe.RecipeName;
                existingRecipe.CategoryCode = updatedRecipe.CategoryCode;
                existingRecipe.PreparationTimeMinutes = updatedRecipe.PreparationTimeMinutes;
                existingRecipe.DifficultyLevel = updatedRecipe.DifficultyLevel;
                existingRecipe.DateAdded = updatedRecipe.DateAdded;
                existingRecipe.Ingredients = updatedRecipe.Ingredients;
                existingRecipe.PreparationSteps = updatedRecipe.PreparationSteps;
                existingRecipe.UserCode = updatedRecipe.UserCode;
                existingRecipe.ImageRoute = updatedRecipe.ImageRoute;

                return Ok(existingRecipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            var recipe = recipeList.Find(x => x.RecipeCode == id);
            if (recipe != null)
                return recipe;
            return null;
        }

















    }
}
