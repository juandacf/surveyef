using Application.Interface;
using Domain.Entities;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SurveysRepository : GenericRepository<Surveys>, ISurveysRepository
    {

        protected readonly TallerSurveyDbContext _context;
        public SurveysRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }

    public  async Task<Surveys> GetByIdAsync(int id) 
{
    return await _context.Surveys 
        .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Survey with id {id} was not found.");
}
    }
}