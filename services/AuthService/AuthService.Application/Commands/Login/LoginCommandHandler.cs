using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginDto, LoginResponseDto>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IAuthTokenService _authTokenService;
        private readonly IMapper _mapper;
        public LoginCommandHandler(IUserRepository repository,
            IUserServices userServices, IAuthTokenService authTokenService, IMapper mapper)
        {
            _repository = repository;
            _userServices = userServices;
            _authTokenService = authTokenService;
            _mapper = mapper;

        }
        public async Task<LoginResponseDto> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.Email);
            if (user == null)
                throw new AuthenticationException("Email or Password Incorrect");
            //if (!user.EmailConfirmed)
            //    throw new AuthenticationException("Email requires confirmation");
            if (_userServices.Login(user, request.Password) == PasswordVerificationResult.Failed)
                throw new AuthenticationException("Email or Password Incorrect");
            var accessToken = _authTokenService.GenerateAccessToken(user);
            var refreshToken = await _authTokenService.GenerateRefreshToken(user);
            object account = user.UserType == UserTypeEnum.Buyer ? _mapper.Map<BuyerResponseDto>(user) :
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
