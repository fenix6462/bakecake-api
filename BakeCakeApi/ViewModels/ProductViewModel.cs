using BakeCakeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ImageProduct> Images { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public ProductViewModel()
        {
            Images = new List<ImageProduct>();
        }
    }
}