using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoriesCatalogRepository : GenericRepository<CategoriesCatalog>, ICategoriesCatalogRepository
    {
        protected readonly TallerSurveyDbContext _context;
        public CategoriesCatalogRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<CategoriesCatalog> GetByIdAsync(int id) 
{
    return await _context.CategoriesCatalogs 
        .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Survey with id {id} was not found.");
}
    }
}