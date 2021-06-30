using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RowebInternship.Api.Data;
using RowebInternship.Api.Domain;
using RowebInternship.Api.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RowebInternship.Api.Controllers
{
    [Route("api/[Product]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        private readonly IHostingEnvironment environment;

        public static List<Product> Products { get; set; }

        public ProductsController(IProductRepository productRepository, IHostingEnvironment environment)
        {
            this.productRepository = productRepository;
            this.environment = environment;
        }
        [HttpGet]
        [Route("/products")]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetProducts();
        }
        [HttpGet]
        [Route("/products/{id}")]
        public Product GetProduct(int id)
        {

            var result = productRepository.GetById(id);
            return result;
        }
        [HttpGet]
        [Route("/category/{id}/products")]
        public IEnumerable<Product> Get(int id, int offset = 0, int limit = 25)
        {
            return productRepository.GetByCategory(id, offset, limit);
        }
        [HttpGet]
        [Route("/categoryProduct")]
        public IEnumerable<CategoryProduct> GetCategoryProduct()
        {
            var categories = productRepository.GetCategoryProducts();
            return categories;
        }

        [HttpPost]
        [Route("/products")]
        public IEnumerable<Product> CreateProduct([FromBody] Product product)
        {

            productRepository.AddProduct(product);
            return productRepository.GetProducts();
        }
        [HttpPut]
        [Route("/products")]
        public void Put(int id, [FromBody] Product product)
        {
            using (RowebContext dbContext = new RowebContext())
            {
                var entity = dbContext.Products.FirstOrDefault(e => e.ProductId == id);
                entity.Name = product.Name;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.BasePrice = product.BasePrice;
                entity.Image = product.Image;
                entity.CategoryID = product.CategoryID;

                dbContext.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("/products/{id}")]
        public void DeleteProduct(int id)
        {
            Products.Remove(Products.Find(item => item.CategoryID == id));
        }

        [HttpPost("/products/{id}/image")]
        public string SaveImage([FromRoute] int id, [FromForm] IFormFile file)
        {
            
            string directory = Path.Combine(environment.ContentRootPath, "Images/");
            string path = Path.Combine(directory, $"{id}_{file.FileName}");
            Directory.CreateDirectory(directory);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var product = productRepository.GetById(id);
            product.Image = file.FileName;
            productRepository.UpdateProduct(product);

            return file.FileName;
        }
    }
}

