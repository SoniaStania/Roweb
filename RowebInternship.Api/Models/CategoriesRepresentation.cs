using RowebInternship.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowebInternship.Api.Models
{
    public class CategoriesRepresentation
    {
        public CategoriesRepresentation()
        {
        }

        public CategoriesRepresentation(List<Category> categories)
        {
            this.Categories = categories.Select(x => new CategoryRepresentation (x)).ToList();
        }

        public List<CategoryRepresentation> Categories { get; set; }

    }
}
