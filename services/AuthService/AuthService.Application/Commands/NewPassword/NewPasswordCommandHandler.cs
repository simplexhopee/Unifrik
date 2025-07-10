﻿using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Common.Shared.Exceptions;

namespace AuthService.Application.Commands.NewPassword
{
    public class NewPasswordCommandHandler : IRequestHandler<NewPasswordDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _userServices;

        public NewPasswordCommandHandler(IUserRepository userRepository,
            IUserServices userServices)
        {
            _userRepository = userRepository;
            _userServices = userServices;
        }
        public async Task Handle(NewPasswordDto request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null) 
                throw new EntityNotFoundException("Email not found");
            var tokenStatus = await _userServices.VerifyPasswordResetToken(user, request.Token);
            if (tokenStatus == false) 
                throw new ArgumentException("Token invalid");
            await _userServices.ResetPassword(user, request.Password, request.Token);
        }
    }
}
