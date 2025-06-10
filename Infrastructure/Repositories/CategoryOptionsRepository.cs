using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryOptionsRepository : GenericRepository<CategoryOptions>, ICategoryOptionsRepository
    {
        protected readonly TallerSurveyDbContext _context;
        public CategoryOptionsRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }
public new async Task<CategoryOptions> GetByIdAsync(int id) 
{
    return await _context.CategoryOptions 
        .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Survey with id {id} was not found.");
}
        
    }
}