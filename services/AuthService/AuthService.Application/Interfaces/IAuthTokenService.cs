using AuthService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Interfaces
{
    public interface IAuthTokenService
    {
        string GenerateAccessToken(User user);
        Task<string> GenerateRefreshToken(User user);
        Task<bool> IsValid(string token);
        Task RevokeToken(string token);
        Task<string> GetUserId(string token);
    }
}
