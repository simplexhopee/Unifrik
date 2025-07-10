using AuthService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand>
    {
        private readonly IUserServices _userServices;
        private readonly IUserRepository _repository;

        public ConfirmEmailCommandHandler(IUserServices userServices, IUserRepository repository)
        {
            _userServices = userServices;
            _repository = repository;
        }
        public async Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.email);
            if (user == null)
                throw new EntryPointNotFoundException("Email invalid");
            var isTokenValid = await _userServices.CheckConfirmEmailToken(user, request.token);
            if (!isTokenValid)
                throw new ArgumentException("Token invalid");
           await _userServices.ConfirmEmail(user, request.token);
        }
    }
}
