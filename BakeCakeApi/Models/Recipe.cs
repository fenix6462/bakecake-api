using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Models
{
    public class Recipe : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ImageRecipe> Images { get; set; }
        public ICollection<RecipeProducts> RecipeProducts { get; set; }
        public Recipe()
        {
            Images = new List<ImageRecipe>();
            RecipeProducts = new List<RecipeProducts>();
        }
    }
}