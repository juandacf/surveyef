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
    public class OptionQuestionsRepository : GenericRepository<OptionQuestions>, IOptionQuestionsRepository
    {
        private readonly TallerSurveyDbContext _context;
        public OptionQuestionsRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }

            public new async Task<OptionQuestions> GetByIdAsync(int id) 
{
    return await _context.OptionQuestions 
        .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Survey with id {id} was not found.");
}
    }
}