using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interface
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<Member> GetByUsernameAsync(string username);
        
        Task<Member> GetByRefreshTokenAsync(string refreshToken);
    }
}