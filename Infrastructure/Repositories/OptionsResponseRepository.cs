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

public class OptionsResponseRepository : GenericRepository<OptionsResponse>, IOptionsResponseRepository
{
    private readonly TallerSurveyDbContext _context;

    public OptionsResponseRepository(TallerSurveyDbContext context) : base(context)
    {
        _context = context;
    }
    
    public new async Task<OptionsResponse> GetByIdAsync(int id) 
{
    return await _context.OptionsResponses 
        .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Survey with id {id} was not found.");
}
}
