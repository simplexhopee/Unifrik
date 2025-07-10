using AuthService.Domain.Entities;


namespace AuthService.Application.Interfaces
{
    public interface IUserRepository 
    {
        Task<bool> Exists(string email);
        Task<User?> GetByEmail(string email);
        Task<User> GetByIdAsync(string id);
    }
}
