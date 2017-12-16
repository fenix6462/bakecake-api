using BakeCakeApi.Models;
using BakeCakeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Mapper
{
    static public class RecipeMapper
    {
        static public RecipeViewModel RecipeViewModelMapper(Recipe recipe)
        {
            return new RecipeViewModel()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                Images = recipe.Images.ToList(),
                Products = recipe.RecipeProducts.Select(xx => new RecipeProductsViewModel
                {
                    Product = ProductMapper.ProductViewModelMapper(xx.Product),
                    Weight = xx.Weight,
                    Price = xx.Product.Price * xx.Weight / xx.Product.Weight
                }).ToList(),
                TotalPrice = recipe.RecipeProducts.Select(x => x.Product.Price * x.Weight / x.Product.Weight).Sum()
            };
        }
    }
}