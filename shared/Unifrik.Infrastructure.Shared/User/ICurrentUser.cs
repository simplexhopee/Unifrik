

using Unifrik.Domain.Shared.Enums;

namespace Unifrik.Infrastructure.Shared.User
{
    public interface ICurrentUser
    {
        string Email { get; }
        string Role { get; }
        UserTypeEnum UserType { get; }
        string LanguagePreference { get; }
        string Currency { get; }

        void SetUser(string email, string role, UserTypeEnum userType, string Language, string Currency);

    }
}
