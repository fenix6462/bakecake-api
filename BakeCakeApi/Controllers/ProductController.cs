using BakeCakeApi.Mapper;
using BakeCakeApi.Models;
using BakeCakeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BakeCakeApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        ApplicationDbContext _context;
        ProductController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetProducts()
        {
            ICollection<ProductViewModel> products = _context.Products
                .Where(x => x.IsDeleted == false).ToList()
                .Select(x => ProductMapper.ProductViewModelMapper(x)).ToList();
            return Ok(products);
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _context.Products.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if(product == null)
            {
                return NotFound();
            }
            return Ok(ProductMapper.ProductViewModelMapper(product));
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Product model)
        {
            Product newProduct = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Images = model.Images,
                Price = model.Price,
                Weight = model.Weight

            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return Ok(newProduct);

        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            Product product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if(product == null)
            {
                return NotFound();
            }

            ICollection<RecipeProducts> recipeProducts = _context.RecipeProducts.Include(x => x.Product).Where(x => x.Product.Id == product.Id).ToList();

            foreach(RecipeProducts recipeProduct in recipeProducts)
            {
                _context.RecipeProducts.Remove(recipeProduct);
            }
            product.IsDeleted = true;
            product.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok();

        }


        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(int id, Product model)
        {
            Product product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Weight = model.Weight;
            product.Images = model.Images;
            product.UpdatedAt = DateTime.Now;
            
            _context.SaveChanges();
            return Ok(product);

        }
    }
}
