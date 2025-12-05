using AuthService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Interfaces
{
    public interface IUserServices
    {
        Task ResetPassword(User user, string password, string token);
        Task<string> GeneratePasswordResetToken(User user);
        Task<User> NewUser(User user, string password);
        Task<User> UpdateUser(string email, User user);
        Task<bool> VerifyPasswordResetToken(User user, string token);
        PasswordVerificationResult Login(User user, string password);
        Task<string> GenerateEmailConfirmToken(User user);

        Task<bool> CheckConfirmEmailToken(User user, string token);
        Task ConfirmEmail(User user, string token);
    }
}
