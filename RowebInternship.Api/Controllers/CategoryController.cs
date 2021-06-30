using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RowebInternship.Api.Domain;
using RowebInternship.Api.Models;
using RowebInternship.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RowebInternship.Api.Controllers
{
    [Route("api/[Category]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> Categories { get; set; }
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
           
            this.categoryRepository = categoryRepository;

        }
        [HttpGet]
        [Route("/category")]
        public IEnumerable<CategoryRepresentation> Get()
        {
            return categoryRepository.GetCategories();
            
        }
        [HttpGet]
        [Route("/category/{id}")]
        public CategoryRepresentation Get(int id)
        {

            var result = categoryRepository.GetById(id);

            if (result == null) return new CategoryRepresentation();

            return new CategoryRepresentation(result);
        }
        

        [HttpPost]
        [Route("/category")]
        public List<CategoryRepresentation> Post([FromBody]CategoryRepresentation category)
        {
            categoryRepository.AddCategory(category.GetEntity());
            return categoryRepository.GetCategories();

           
        }

        [HttpPut]
        [Route("/category")]
        public CategoryRepresentation Put(int id, CategoryRepresentation category)
        {
            var ProductToUpdate = categoryRepository.GetById(id);

            if (ProductToUpdate == null)
            {
                return null;
            }
            ProductToUpdate.Name = category.Name;

            return new CategoryRepresentation(ProductToUpdate);
        }


        [HttpDelete]
        [Route("/category/{id}")]
        public void Delete(int id)
        {
            categoryRepository.DeleteCategory(id);
        }
    }
}
