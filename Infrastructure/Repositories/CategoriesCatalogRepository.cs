using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;

namespace Infrastructure.Repositories
{
    public class CategoriesCatalogRepository : GenericRepository<CategoriesCatalog>, ICategoriesCatalogRepository
    {
        protected readonly TallerSurveyDbContext _context;
        public CategoriesCatalogRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}