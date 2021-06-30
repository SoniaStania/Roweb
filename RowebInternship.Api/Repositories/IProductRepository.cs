using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RowebInternship.Api.Domain;

namespace RowebInternship.Api.Repositories
{
  public  interface IProductRepository
    {
        List<Product> GetProducts();
        public Product GetById(int id);
        public void AddProduct(Product product);
        public void  UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        IEnumerable<Product> GetByCategory(int id, int offset, int limit);
        public List<CategoryProduct> GetCategoryProducts();
    }
}
