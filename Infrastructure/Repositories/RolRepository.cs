using Application.Interface; 
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data; 
namespace Infrastructure.Repositories; 
public class RolRepository : GenericRepository<Rol>, IRolRepository { 
    protected readonly TallerSurveyDbContext _context;
    public RolRepository(TallerSurveyDbContext context) : base(context) {} 
} 