using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Unifrik.Infrastructure.Shared.Database.Interfaces;

namespace AuthService.Infrastructure.Auth
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;
        public UserServices(UserManager<User> userManager, IUnitOfWork unitOfWork, IUserRepository repository)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task ResetPassword(User user, string password, string token)
        {
            await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<string> GeneratePasswordResetToken(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

      

        public async Task<User> NewUser(User user, string password)
        {
            await _userManager.CreateAsync(user, password);
            var createdUser = await _repository.GetByEmail(user!.Email!);
            return createdUser!;
        }

        public async Task<bool> VerifyPasswordResetToken(User user, string token)
        {
            return await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
        }

        public PasswordVerificationResult Login(User user, string password)
        {
            return _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash!, password);
        }

        public async Task<string> GenerateEmailConfirmToken(User user)
        {
            return await _userManager.GenerateUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider, "ConfirmEmail");
        }

        public async Task<bool> CheckConfirmEmailToken(User user, string token)
        {
            return await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider, "ConfirmEmail", token);
        }

        public async Task ConfirmEmail(User user, string token)
        {
            await _userManager.ConfirmEmailAsync(user, token);
        }
    }
}
