using BakeCakeApi.Models;
using BakeCakeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Mapper
{
    static public class ProductMapper
    {
        static public ProductViewModel ProductViewModelMapper(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Images = product.Images.ToList(),
                Price = product.Price,
                Weight = product.Weight
            };
        }
    }
}