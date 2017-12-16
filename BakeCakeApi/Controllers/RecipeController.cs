using BakeCakeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using BakeCakeApi.ViewModels;
using BakeCakeApi.Mapper;

namespace BakeCakeApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/recipe")]
    public class RecipeController : ApiController
    {
        ApplicationDbContext _context;
        RecipeController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetRecipes()
        {
            ICollection<RecipeViewModel> recipes = _context.Recipes
                .Include(x => x.RecipeProducts.Select(xx => xx.Product))
                .Include(x => x.Images)
                .Where(x => x.IsDeleted == false).ToList()
                .Select(x => RecipeMapper.RecipeViewModelMapper(x)).ToList();
            return Ok(recipes);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetRecipe(int id)
        {
            Recipe recipe = _context.Recipes.Include(x => x.RecipeProducts.Select(xx => xx.Product)).Include(x => x.Images).Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if(recipe == null)
            {
                return NotFound();
            }
            return Ok(RecipeMapper.RecipeViewModelMapper(recipe));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            Recipe recipe = _context.Recipes.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if (recipe == null)
            {
                return NotFound();
            }
            recipe.IsDeleted = true;
            recipe.DeletedAt = DateTime.Now;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(RecipeViewModel model)
        {
            Recipe recipe = new Recipe()
            {
                Name = model.Name,
                Description = model.Description
            };

            foreach(RecipeProductsViewModel recipeProduct in model.Products)
            {
                Product product = _context.Products.Where(x => x.Id == recipeProduct.Product.Id).FirstOrDefault();
                if (product != null)
                {
                    recipe.RecipeProducts.Add(new RecipeProducts() {
                        Product = product,
                        Weight = recipeProduct.Weight
                    });
                }
            }
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return Ok(RecipeMapper.RecipeViewModelMapper(recipe));
        }
    }
}
