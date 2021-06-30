using Microsoft.EntityFrameworkCore;
using RowebInternship.Api.Data;
using RowebInternship.Api.Domain;
using RowebInternship.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowebInternship.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RowebContext db;

        public CategoryRepository(RowebContext db)
        {
            this.db = db;
        }

        public List<CategoryRepresentation> GetCategories(int offset, int limit)
        {
            return db.Categories.OrderBy(x => x.Name).Skip(offset).Take(limit).Select(x=>new CategoryRepresentation(x)).ToList();

        }

        public Category GetById(int categoryID)
        {
            return  db.Categories.Where(e => e.CategoryID == categoryID).First();
        }

       

        public Category AddCategory(Category category)
        {

             db.Categories.Add(category);
             db.SaveChanges();
            return category;

        }

        public Category UpdateCategory(Category category)
        {
            var result =  db.Categories
            .FirstOrDefault(e => e.CategoryID == category.CategoryID);

            if (result != null)
            {
                result.Name = category.Name;
                result.Description = category.Description;

                db.SaveChanges();

                return result;
            }

            return null;
        }

        public Category DeleteCategory(int categoryID)
        {

            var result =  db.Categories
            .FirstOrDefault(e => e.CategoryID == categoryID);
            if (result != null)
            {
                db.Categories.Remove(result);
                db.SaveChanges();
                return result;
            }
            return null;

        }
    }
}
