using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthTokenService _authTokenService;
        private readonly IMapper _mapper;

        public RefreshTokenCommandHandler(IUserRepository userRepository, IAuthTokenService authTokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authTokenService = authTokenService;
            _mapper = mapper;
           
        }
        public async Task<LoginResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var isValid = await _authTokenService.IsValid(request.token);
            if (!isValid)
                throw new AuthenticationException("Invalid or Expired Token");
            var userId = await _authTokenService.GetUserId(request.token);
            var user = await _userRepository.GetByIdAsync(userId);
            var accessToken = _authTokenService.GenerateAccessToken(user!);
            var refreshToken = await _authTokenService.GenerateRefreshToken(user!);
            await _authTokenService.RevokeToken(request.token);
            UserDto account = user.UserType == UserTypeEnum.Buyer ? _mapper.Map<BuyerResponseDto>(user) :
               user.UserType == UserTypeEnum.Seller ? _mapper.Map<SellerResponseDto>(user) :
                _mapper.Map<LogisticsResponseDto>(user);
            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Account = account,
            };
        }
    }
}
