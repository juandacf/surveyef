using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Auth;

namespace ApiSurvey.Services
{
    public class UserService : IUserService
    {
        public Task<string> AddRoleAsync(AddRoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<DataUserDTO> GetTokenAsync(LoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<DataUserDTO> RefreshTokenAsync(string RefreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync(RegisterDTO model)
        {
            throw new NotImplementedException();
        }
    }
}