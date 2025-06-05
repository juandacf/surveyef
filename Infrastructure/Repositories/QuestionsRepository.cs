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
    public class QuestionsRepository : GenericRepository<Questions>, IQuestionsRepository
    {
        protected readonly TallerSurveyDbContext _context;
        public QuestionsRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}