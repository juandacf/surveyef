using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChaptersRepository : GenericRepository<Chapters>, IChaptersRepository
{
    protected readonly TallerSurveyDbContext _context;
    public ChaptersRepository(TallerSurveyDbContext context) : base(context)
    {
        _context = context;
    }

    public new async Task<Chapters> GetByIdAsync(int id) 
{
    return await _context.Chapters 
        .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Survey with id {id} was not found.");
}
}
