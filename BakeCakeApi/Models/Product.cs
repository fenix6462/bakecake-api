using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Models
{
    public class Product : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ImageProduct> Images { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public Product()
        {
            Images = new List<ImageProduct>();
        }
    }
}