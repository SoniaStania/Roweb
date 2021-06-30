using RowebInternship.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowebInternship.Api.Models
{
    public class CategoryRepresentation
    {
        public CategoryRepresentation()
        {

        }

        public CategoryRepresentation(Category result)
        {
            CategoryID = result.CategoryID;
            Name = result.Name;
        }

        public long CategoryID  { get; set; }
        public string Name { get; set; }

        internal Category GetEntity()
        {
            
            return new Category
            {
                CategoryID = CategoryID,
                Name = Name,

            };

        }
    }
}
