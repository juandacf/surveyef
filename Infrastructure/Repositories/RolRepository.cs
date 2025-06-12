using Application.Interface; 
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories; 
public class RolRepository : GenericRepository<Rol>, IRolRepository { 
    protected readonly TallerSurveyDbContext _context;
    public RolRepository(TallerSurveyDbContext context) : base(context) {}

    public async Task<Rol> GetByUsernameAsync(string username)
    {
        return await _context.Rol
                        .Include(u=>u.Members)
                        .FirstOrDefaultAsync(u=>u.Name.ToLower()==username.ToLower());
    }
    public void Attach(Rol rol)
    {
        throw new NotImplementedException();
    }
} 