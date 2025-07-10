using AuthService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Common.Shared.Exceptions;

namespace AuthService.Application.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, string>
    {
        private readonly IUserServices _userServices;
        private readonly IUserRepository _repository;
       
        public ResetPasswordCommandHandler(IUserServices userServices,
            IUserRepository repository)
        {
            _userServices = userServices;
            _repository = repository;
           

        }
        public async Task<string> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.email);
            if (user == null)
            {
                throw new EntityNotFoundException("The email does not match our records");
            }
           return await _userServices.GeneratePasswordResetToken(user);
           
           

        }
    }
}
