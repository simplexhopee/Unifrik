using AuthService.Application.Dtos;
using MediatR;


namespace AuthService.Application.Commands.RefreshToken
{
    public record RefreshTokenCommand(string token) : IRequest<LoginResponseDto>;
}
