using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class SubQuestionsRepository : GenericRepository<SubQuestions>, ISubQuestionsrepository
    {
        private readonly TallerSurveyDbContext _context;

        public SubQuestionsRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}