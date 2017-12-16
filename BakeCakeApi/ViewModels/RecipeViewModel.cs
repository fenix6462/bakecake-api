using BakeCakeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float TotalPrice { get; set; }
        public ICollection<ImageRecipe> Images { get; set; }
        public ICollection<RecipeProductsViewModel> Products { get; set; }
        public RecipeViewModel()
        {
            Images = new List<ImageRecipe>();
            Products = new List<RecipeProductsViewModel>();
        }
    }
}