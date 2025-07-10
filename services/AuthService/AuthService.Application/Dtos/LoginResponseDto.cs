

using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Dtos
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime AccessExpiry { get; set; } = DateTime.Now.AddHours(4);
        public DateTime RefreshExpiry { get; set; } = DateTime.Now.AddDays(7);
        public UserTypeEnum UserType { get; set; }
        public object Account { get; set; } = default!;
    }
}
