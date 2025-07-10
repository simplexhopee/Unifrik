using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Infrastructure.Shared.Database.Infrastructure;
using Unifrik.Infrastructure.Shared.User;

namespace AuthService.Infrastructure.DbContext
{
    public class UserDbContext : ApplicationDbContext
    {
        public UserDbContext(
            DbContextOptions<UserDbContext> options,
            ICurrentUser currentUser) : base(options, currentUser)
        {
        }

        public DbSet<User> Users { get; set; }
       
        
    }
}
