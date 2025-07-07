using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Infrastructure.Shared.Enums;

namespace Unifrik.Infrastructure.Shared.User
{
    public class CurrentUser : ICurrentUser
    {
        public string? Email { get; private set; }
        public List<string> Roles { get; private set; } = new List<string>();
        public List<string> Permissions { get; private set; } = new List<string>();

        public UserTypeEnum UserType { get; private set; }

        public string LanguagePreference { get; private set; }

        public string Currency { get; private set; }

        public void SetUser(string email, List<string> roles, List<string> permissions)
        {
            if (!string.IsNullOrEmpty(Email)) throw new InvalidOperationException("Current User is set already");
            Email = email;
            Roles = roles;
            Permissions = permissions;

        }

        public void SetUser(string email, List<string> roles, List<string> permissions, 
            UserTypeEnum userType, string languagePreference, string currency)
        {
            if (!string.IsNullOrEmpty(Email)) throw new InvalidOperationException("Current User is set already");
            Email = email;
            Roles = roles;
            Permissions = permissions;
            UserType = userType;
            LanguagePreference = languagePreference;
            Currency = currency;


        }
    }
}
