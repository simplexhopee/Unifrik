using MediatR;
using System.ComponentModel.DataAnnotations;


namespace AuthService.Application.Dtos
{
    public class LoginDto : IRequest<LoginResponseDto>
    {
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
