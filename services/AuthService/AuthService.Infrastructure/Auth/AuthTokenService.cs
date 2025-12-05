using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Redis;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Unifrik.Infrastructure.Shared.Configuration.Models;


namespace AuthService.Infrastructure.Auth
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly RedisService _redisService;

        public AuthTokenService(IOptions<JwtSettings> jwtSettings, RedisService redisService)
        {
            _jwtSettings = jwtSettings.Value;
            _redisService = redisService;
        }
        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Email , user.Email!),
                new Claim(ClaimTypes.Name, user.Name!.ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),

            };

            var keyBytes = Convert.FromBase64String(_jwtSettings.IssuerSigningKey?? "");
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateRefreshToken(User user)
        {
            var token = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                UserId = user.Id,
               
            };
            string redisKey = $"refresh:{token.Token}";
            await _redisService.SetValueAsync(redisKey, 
                System.Text.Json.JsonSerializer.Serialize(token), token.ExpiresAt - DateTime.UtcNow);
            return token.Token;

        }

        public async Task RevokeToken(string token)
        {
            await _redisService.DeleteAsync($"refresh:{token}");
        }

        public async Task<bool> IsValid(string token)
        {
            return await _redisService.GetValueAsync(
                $"refresh:{token}")  != null;
        }

        public async Task<string> GetUserId(string token)
        {
            var rawTokenObj = await _redisService.GetValueAsync($"refresh:{token}");
            var tokenObject = System.Text.Json.JsonSerializer.Deserialize<RefreshToken>(rawTokenObj!);
            return tokenObject!.UserId;
        }
    }
}
