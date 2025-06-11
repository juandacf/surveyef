using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Auth;

namespace ApiSurvey.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDTO model);
        Task<DataUserDTO> GetTokenAsync(LoginDTO model);
        Task<string> AddRoleAsync(AddRoleDTO model);
        Task<DataUserDTO> RefreshTokenAsync(string RefreshToken);
    }
}