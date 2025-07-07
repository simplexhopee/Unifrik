using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Infrastructure.Shared.Enums;

namespace Unifrik.Infrastructure.Shared.User
{
    public interface ICurrentUser
    {
        string Email { get; }
        List<string> Roles { get; }
        List<string> Permissions { get; }
        UserTypeEnum UserType { get; }
        string LanguagePreference { get; }
        string Currency { get; }

        void SetUser(string email, List<string> roles, List<string> permissions, 
            UserTypeEnum userType, string Language, string Currency);

    }
}
