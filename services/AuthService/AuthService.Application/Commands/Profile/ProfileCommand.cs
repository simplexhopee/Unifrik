using AuthService.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Commands.Profile
{
    public record ProfileCommand(string email) : IRequest<object>
    {
    }
}
