using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryOptions
    {
        public int Id { get; set; }
        public int CatalogOptionsId { get; set; }
        public CategoriesCatalog CategoriesCatalog { get; set; }
        public int CategoriesOptionsId { get; set; }
        public OptionsResponse OptionsResponse { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}