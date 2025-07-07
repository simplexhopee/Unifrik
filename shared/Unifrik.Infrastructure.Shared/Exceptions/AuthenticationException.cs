

namespace Unifrik.Infrastructure.Shared.Exceptions
{
    [Serializable]
    public class AuthenticationException : Exception
    {


        public AuthenticationException(string? message) : base(message)
        {
        }

    }
}
