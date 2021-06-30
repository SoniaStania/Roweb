using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowebInternship.Api.Domain
{
    public class CategoryProduct
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int BasePrice { get; set; }
        public string Image { get; set; }
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
