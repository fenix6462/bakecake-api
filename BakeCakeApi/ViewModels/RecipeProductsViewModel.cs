using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.ViewModels
{
    public class RecipeProductsViewModel
    {
        public ProductViewModel Product { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
    }
}