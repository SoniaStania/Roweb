using RowebInternship.Api.Domain;
using RowebInternship.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowebInternship.Api.Repositories
{
    public interface ICategoryRepository
    {
        public List<CategoryRepresentation> GetCategories(int offset =0, int limit = 25);
        public Category GetById(int id);
        public Category AddCategory(Category category);
        public Category UpdateCategory(Category category);
        public Category DeleteCategory(int categoryID);
        
    }
}
