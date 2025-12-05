using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Domain.Shared.Enums;


namespace Unifrik.Infrastructure.Shared.User
{
    public class CurrentUser : ICurrentUser
    {
        public string? Email { get; private set; }
        public string Role { get; private set; } = default!;
        public UserTypeEnum UserType { get; private set; }

        public string LanguagePreference { get; private set; } = default!;

        public string Currency { get; private set; } = default!;

      
        public void SetUser(string email,  UserTypeEnum userType, string languagePreference = "", string currency = "")
        {
            if (!string.IsNullOrEmpty(Email)) throw new InvalidOperationException("Current User is set already");
            Email = email;
            UserType = userType;
            LanguagePreference = languagePreference;
            Currency = currency;


        }
    }
}
