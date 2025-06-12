using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;

namespace Infrastructure.Repositories
{
    public class MemberRolRepository : GenericRepository<MemberRols>, IMemberRolsRepository
    {
        private readonly TallerSurveyDbContext _context;
        
        public MemberRolRepository(TallerSurveyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}