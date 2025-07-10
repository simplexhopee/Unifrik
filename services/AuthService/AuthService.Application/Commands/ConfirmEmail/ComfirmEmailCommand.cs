﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Commands.ConfirmEmail
{
    public record ConfirmEmailCommand(string email, string token) : IRequest;
    
}
