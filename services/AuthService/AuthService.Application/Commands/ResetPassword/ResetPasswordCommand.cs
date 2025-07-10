using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Commands.ResetPassword
{
    public record ResetPasswordCommand(string email) : IRequest<string>;
}
