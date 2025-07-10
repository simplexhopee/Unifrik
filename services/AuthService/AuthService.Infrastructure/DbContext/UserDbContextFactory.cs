using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Infrastructure.Shared.User;

namespace AuthService.Infrastructure.DbContext
{
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();


            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>()
                .UseNpgsql(config.GetConnectionString("User"));
               
      
            var user = new CurrentUser();

            return new UserDbContext(optionsBuilder.Options,  user);


        }
    }
}
