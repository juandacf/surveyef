using Application.Interface; 
using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories; 
public class MemberRepository : GenericRepository<Member>, IMemberRepository { 
    protected readonly TallerSurveyDbContext _context;
    public MemberRepository(TallerSurveyDbContext context) : base(context) {}
    public async Task<Member> GetByUsernameAsync(string username)
    {
        return await _context.Member
                        .Include(u=>u.Roles)
                        .FirstOrDefaultAsync(u=>u.Username.ToLower()==username.ToLower());
    }
} 