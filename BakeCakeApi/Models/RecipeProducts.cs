using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Models
{
    public class RecipeProducts
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Recipe Recipe { get; set; }
        public float Weight { get; set; }
    }
}