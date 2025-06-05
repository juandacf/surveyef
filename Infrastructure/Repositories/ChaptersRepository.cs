using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ChaptersRepository : GenericRepository<Chapters>, IChaptersRepository
{
    protected readonly TallerSurveyDbContext _context;
    public ChaptersRepository(TallerSurveyDbContext context) : base(context)
    {
        _context = context;
    }
}
