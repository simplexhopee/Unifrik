using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Unifrik.Infrastructure.Shared.Database.Infrastructure;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, string, UserDbContext>, IUserRepository
    {
        private readonly DbSet<User> _users;
        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
        }

       

        public async Task<bool> Exists(string email)
        {
            return await _users.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _users.FirstOrDefaultAsync(u => u.Email == email);
        }


    }
}
