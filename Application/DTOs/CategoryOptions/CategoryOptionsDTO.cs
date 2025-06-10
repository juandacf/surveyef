using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.CategoriesCatalog;
using Application.DTOs.OptionsResponse;


namespace Application.DTOs.CategoryOptions
{
    public class CategoryOptionsDTO
    {
        public int Id { get; set; }
        public int CatalogOptionsId { get; set; }
        public CategoriesCatalogDTO CategoriesCatalogDTO { get; set; }
        public int CategoriesOptionsId { get; set; }
        public OptionsResponseDTO OptionsResponseDTO { get; set; }
    }
}