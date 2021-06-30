using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RowebInternship.Api.Data;
using RowebInternship.Api.Domain;

namespace RowebInternship.Api.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly RowebContext db;

        public ProductRepository(RowebContext db)
        {
            this.db = db;
        } 

        public List<Product> GetProducts()
        {
            return  db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Where(e => e.CategoryID == id).First();          
        }

        public void  AddProduct(Product product)
        {
            db.Products.Add(product);
             db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();  
        }

        public void DeleteProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetByCategory(int id, int offset, int limit)
        {
            return (from p in db.Products where p.CategoryID == id select p).ToList();
        }

        public List<CategoryProduct> GetCategoryProducts()
        {
            return (from p in db.Products
                    join c in db.Categories on p.CategoryID equals c.CategoryID
                    
                    select new CategoryProduct()
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        BasePrice = p.BasePrice,
                        Image = p.Image,
                        CategoryName = c.Name
                    }).ToList();
        }
    }
}

